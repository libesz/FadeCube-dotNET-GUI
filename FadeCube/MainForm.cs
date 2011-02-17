using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms.Layout;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FadeCube
{
    public partial class MainForm : Form
    {
        private CubeAnimationData Animation;
        private Point layerDataLocation = new Point( 16, 19 );
        FormCubeLayerVisualiser layerVisulaiser;// = new FormCubeLayerVisualiser();
        guiOptions GuiOptions;
        areYouSureAnswer AreYouSureAnswer = new areYouSureAnswer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GuiOptions = guiOptionsHandler.loadOptions();

            if ((GuiOptions.animationPath is string) && (GuiOptions.animationPath != ""))
            {
                if (!loadAnimation(GuiOptions.animationPath))
                {
                    newAnimation();
                }
            }
            else
            {
                newAnimation();
            }
            refreshFrameListDS();
            layerVisulaiser = new FormCubeLayerVisualiser(frameDataGroupBox.Controls, layerDataLocation, GuiOptions, this);
            
            //ugly part, at startup, the layerVisualiser object does not exists, so event can not assigned in designer
            //but is assigned here, thing has to be made as well here (update textboxes, etc)
            frameList.SelectedIndexChanged += new EventHandler(frameList_SelectedIndexChanged);
            layerVisulaiser.actualFrameData = Animation.Frames[0].FrameData;
            frameNameTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameName;

            refreshFrameListDS();

            btnMoveUp.Enabled = false;
            switch (GuiOptions.selectedBrightness)
            {
                case 0: brightnessRadio0.Checked = true;
                    break;
                case 1: brightnessRadio1.Checked = true;
                    break;
                case 2: brightnessRadio2.Checked = true;
                    break;
                case 3: brightnessRadio3.Checked = true;
                    break;
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            guiOptionsHandler.saveOptions(GuiOptions);
        }

        /*protected override void OnPaint(PaintEventArgs e)
        {
            Point p1 = new Point(0, ClientSize.Height / 2);
            Point p2 = new Point(ClientSize.Width, ClientSize.Height / 2);
            e.Graphics.DrawLine(new Pen(Color.Black), p1, p2);

            p1 = new Point(ClientSize.Width / 2, 0);
            p2 = new Point(ClientSize.Width / 2, ClientSize.Height);
            e.Graphics.DrawLine(new Pen(Color.Black), p1, p2);
        }*/

        private void refreshFrameListDS()
        {
            frameList.BeginUpdate();
            frameList.DataSource = null;
            frameList.DataSource = Animation.Frames;
            frameList.DisplayMember = "FrameName";
            frameList.EndUpdate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CubeAnimation.addFrameToAnimation(Animation, validateFrameNameField(frameNameTextBox.Text), validateTimeField( frameTimeTextBox.Text ));
            refreshFrameListDS();
            frameList.SelectedIndex = frameList.Items.Count - 1;
            GuiOptions.notSaved = true;
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            CubeAnimation.duplicateFrameInAnimation(Animation, frameList.SelectedIndex, validateFrameNameField(frameNameTextBox.Text), validateTimeField(frameTimeTextBox.Text));
            refreshFrameListDS();
            //frameList.SelectedIndex = frameList.Items.Count - 1;
            GuiOptions.notSaved = true;
        }

        public static string validateFrameNameField( string text )
        {
            if (text == "")
            {
                MessageBox.Show("Frame name can not be empty");
                return "untitled frame";
            }
            return text;
        }

        public static int validateTimeField( string text )
        {
            try
            {
                int time = Int32.Parse(text);
                if( time >= 20 && time <= 10000 )
                {
                    return time;
                }
                else
                {
                    MessageBox.Show("Time should be between 20ms and 10000ms");
                    return 50;
                }
            }
            catch
            {
                return 50;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Animation.Frames[frameList.SelectedIndex].FrameData = "bla";
            if ((frameList.SelectedIndex > -1) && (frameList.Items.Count > 1))
            {
                CubeAnimation.removeFrameFromAnimation(Animation, frameList.SelectedIndex);
                refreshFrameListDS();
                GuiOptions.notSaved = true;
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (frameList.SelectedIndex > 0)
            {
                CubeAnimation.moveUpFrameInAnimation(Animation, frameList.SelectedIndex);
                refreshFrameListDS();
                frameList.SelectedIndex = frameList.SelectedIndex - 1;
                GuiOptions.notSaved = true;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (frameList.SelectedIndex < ( Animation.Frames.Length - 1) )
            {
                CubeAnimation.moveDownFrameInAnimation(Animation, frameList.SelectedIndex);
                refreshFrameListDS();
                frameList.SelectedIndex = frameList.SelectedIndex + 1;
                GuiOptions.notSaved = true;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Animation.Frames[frameList.SelectedIndex].FrameName = validateFrameNameField( frameNameTextBox.Text );
            Animation.Frames[frameList.SelectedIndex].FrameTime = validateTimeField( frameTimeTextBox.Text );
            refreshFrameListDS();
            GuiOptions.notSaved = true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animationOpenDialog.ShowDialog();
            if (animationOpenDialog.FileName != "")
            {
                loadAnimation( animationOpenDialog.FileName );
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GuiOptions.animationPath != "")
            {
                CubeAnimation.saveAnimation(Animation, GuiOptions.animationPath);
                GuiOptions.notSaved = false;
            }
            else
            {
                saveWithDialog();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveWithDialog();
        }

        private void frameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frameList.SelectedIndex > -1)
            {
                if (frameList.SelectedIndex == 0)
                {
                    btnMoveUp.Enabled = false;
                }
                else
                {
                    btnMoveUp.Enabled = true;
                }
                if (frameList.SelectedIndex == ( Animation.Frames.Length - 1 ))
                {
                    btnMoveDown.Enabled = false;
                }
                else
                {
                    btnMoveDown.Enabled = true;
                }

                frameNameTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameName;
                frameTimeTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameTime.ToString();
                layerVisulaiser.actualFrameData = Animation.Frames[ frameList.SelectedIndex ].FrameData;
                layerVisulaiser.updateLayerDisplay();
                handleNetwork();
            }
        }

        private void newAnimation()
        {
            Animation = new CubeAnimationData();
            GuiOptions.animationPath = "";
            this.Text = global::FadeCube.Properties.Resources.mainFormTitle + " - " + Animation.GlobalOptions.AnimationName + " (" + GuiOptions.animationPath + ")";
        }

        private bool loadAnimation(string path)
        {
            Animation = CubeAnimation.loadAnimation(path);
            if (Animation is CubeAnimationData)
            {
                refreshFrameListDS();
                GuiOptions.animationPath = path;
                this.Text = global::FadeCube.Properties.Resources.mainFormTitle + " - " + Animation.GlobalOptions.AnimationName + " (" + GuiOptions.animationPath + ")";
                GuiOptions.notSaved = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void saveWithDialog()
        {
            animationSaveDialog.ShowDialog();
            if (animationSaveDialog.FileName != "")
            {
                CubeAnimation.saveAnimation(Animation, animationSaveDialog.FileName);
                GuiOptions.animationPath = animationSaveDialog.FileName;
                this.Text = global::FadeCube.Properties.Resources.mainFormTitle + " - " + Animation.GlobalOptions.AnimationName + " (" + GuiOptions.animationPath + ")";
                GuiOptions.notSaved = false;
            }
        }

        private void layerSelectorTrackBar_Scroll(object sender, EventArgs e)
        {
            selectedLayerLabel2.Text = (layerSelectorTrackBar.Value + 1).ToString();
            layerVisulaiser.actualLayer = layerSelectorTrackBar.Value;
            layerVisulaiser.updateLayerDisplay();
        }
        //common event for the 4 brightness radiobuttons
        private void brightnessRadio_Changed(object sender, EventArgs e)
        {
            GuiOptions.selectedBrightness = Int16.Parse((sender as RadioButton).Text);
        }

        private void btnFillFrame_Click(object sender, EventArgs e)
        {
            CubeAnimation.fillFrameInAnimation(Animation, frameList.SelectedIndex, GuiOptions.selectedBrightness);
            layerVisulaiser.updateLayerDisplay();
            handleNetwork();
            GuiOptions.notSaved = true;
        }

        private void btnFillLayer_Click(object sender, EventArgs e)
        {
            CubeAnimation.fillLayerInAnimation(Animation, frameList.SelectedIndex, layerSelectorTrackBar.Value, GuiOptions.selectedBrightness);
            layerVisulaiser.updateLayerDisplay();
            handleNetwork();
            GuiOptions.notSaved = true;
        }

        private void connectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionsForm connectionForm = new ConnectionsForm(GuiOptions);
            connectionForm.ShowDialog();
        }
        public void handleNetwork()
        {
            if (GuiOptions.useEP1)
            {
                CubeAnimation.sendFramePacket(GuiOptions.endPoint1, Animation.Frames[frameList.SelectedIndex].FrameData);
            }
            if (GuiOptions.useEP2)
            {
                CubeAnimation.sendFramePacket(GuiOptions.endPoint2, Animation.Frames[frameList.SelectedIndex].FrameData);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            handleAreYouSure( false );
            if (AreYouSureAnswer.answer == 3)
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleAreYouSure( true );
            newAnimation();
            refreshFrameListDS();
        }

        private void handleAreYouSure( bool createNew )
        {
            if(GuiOptions.notSaved)
            {
                AreYouSureForm areYouSureForm = new AreYouSureForm(AreYouSureAnswer);
                areYouSureForm.ShowDialog();

                switch (AreYouSureAnswer.answer)
                {
                    case 1:
                        if (GuiOptions.animationPath != "")
                        {
                            CubeAnimation.saveAnimation(Animation, GuiOptions.animationPath);
                            GuiOptions.notSaved = false;
                        }
                        else
                        {
                            saveWithDialog();
                        }
                        if (createNew)
                        {
                            newAnimation();
                        }
                        break;
                    case 2:
                        if( createNew )
                        {
                            newAnimation();
                            layerVisulaiser.updateLayerDisplay();
                        }
                        break;
                }
                refreshFrameListDS();
                //MessageBox.Show(AreYouSureAnswer.answer.ToString());
            }
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = GuiOptions.notSaved;
        }

        private void AnimationPlayerBW_DoWork(object sender, DoWorkEventArgs e)
        {
            CubeAnimationData AnimationData = (e.Argument as AnimationWithGuiOptions).AnimationData;
            do
            {
                for (int i = 0; i < AnimationData.Frames.Length; i++ )
                {
                    AnimationPlayerBW.ReportProgress(1, i);
                    //MainForm.handleNetwork(GuiOptions, Animation.Frames[i].FrameData);
                    Thread.Sleep(AnimationData.Frames[i].FrameTime);
                    if (AnimationPlayerBW.CancellationPending) { e.Cancel = true; return; }
                }
            }while((e.Argument as AnimationWithGuiOptions).GuiOptions.continousPlaying);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            AnimationPlayerBW.RunWorkerAsync( new AnimationWithGuiOptions( Animation, GuiOptions ) );
        }

        private void btnPlay_EnabledChanged(object sender, EventArgs e)
        {
            if ((sender as Button).Enabled)
            {
                btnStop.Enabled = false;
            }
            else
            {
                btnStop.Enabled = true;
            }
        }

        private void btnStop_EnabledChanged(object sender, EventArgs e)
        {
            if ((sender as Button).Enabled)
            {
                btnPlay.Enabled = false;
            }
            else
            {
                btnPlay.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            AnimationPlayerBW.CancelAsync();
        }

        private void AnimationPlayerBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStop.Enabled = false;
        }

        //force to use only digits in time field
        private void frameTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void AnimationPlayerBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            frameList.SelectedIndex = (int)e.UserState;
        }

        private void animationOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnimationOptionsForm animationOptionsForm = new AnimationOptionsForm( GuiOptions, Animation.GlobalOptions );
            animationOptionsForm.ShowDialog();
            this.Text = global::FadeCube.Properties.Resources.mainFormTitle + " - " + Animation.GlobalOptions.AnimationName + " (" + GuiOptions.animationPath + ")";
        }

        private void frameList_DisplayMemberChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = !(frameList.Items.Count == 1);
        }

        private void contCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            GuiOptions.continousPlaying = (sender as CheckBox).Checked;
        }
    }

    public class areYouSureAnswer
    {
        public int answer = 0;
    }

    public class guiOptions
    {
        public bool useEP1 = false;
        public bool useEP2 = false;
        public IPEndPoint endPoint1, endPoint2;
        public string animationPath = "";
        public int selectedBrightness = 3;
        public bool notSaved = false;
        public bool continousPlaying = false;
        //        IPAddress destinationIPaddress = IPAddress.Parse(address);
        //        IPEndPoint ep = new IPEndPoint(destinationIPaddress, port);
    }
    public class guiOptionsFile
    {
        [XmlElement(ElementName = "useEP1")]
        public bool useEP1 = false;
        [XmlElement(ElementName = "useEP2")]
        public bool useEP2 = false;
        [XmlElement(ElementName = "IP1")]
        public string ip1;
        [XmlElement(ElementName = "IP2")]
        public string ip2;
        [XmlElement(ElementName = "port1")]
        public int port1;
        [XmlElement(ElementName = "port2")]
        public int port2;
        [XmlElement(ElementName = "lastPath")]
        public string animationPath = "";
        [XmlElement(ElementName = "selectedBrightness")]
        public int selectedBrightness = 3;
    }
    public class guiOptionsHandler
    {
        public static guiOptions loadOptions()
        {
            guiOptions options = new guiOptions();
            guiOptionsFile optionsFile;
            try
            {
                IPAddress ipa;
                StreamReader sr = File.OpenText(Application.StartupPath + "/fadecube_config.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(guiOptionsFile));
                optionsFile = (guiOptionsFile)serializer.Deserialize(sr);
                sr.Close();
                options.useEP1 = optionsFile.useEP1;
                options.useEP2 = optionsFile.useEP2;
                options.selectedBrightness = optionsFile.selectedBrightness;
                options.animationPath = optionsFile.animationPath;
                try
                {
                    ipa = IPAddress.Parse(optionsFile.ip1);
                    options.endPoint1 = new IPEndPoint(ipa, optionsFile.port1);
                }
                catch
                { }
                try
                {
                    ipa = IPAddress.Parse(optionsFile.ip2);
                    options.endPoint2 = new IPEndPoint(ipa, optionsFile.port2);
                }
                catch
                { }
            }
            catch (FileNotFoundException)
            {
            }
            return options;
        }

        public static void saveOptions(guiOptions options)
        {
            guiOptionsFile optionsFile = new guiOptionsFile();
            optionsFile.useEP1 = options.useEP1;
            optionsFile.useEP2 = options.useEP2;
            optionsFile.selectedBrightness = options.selectedBrightness;
            optionsFile.animationPath = options.animationPath;
            try
            {
                optionsFile.ip1 = options.endPoint1.Address.ToString();
                optionsFile.port1 = options.endPoint1.Port;
            }
            catch { }
            try
            {
               optionsFile.ip2 = options.endPoint2.Address.ToString();
               optionsFile.port2 = options.endPoint2.Port;
            }
            catch { }

            StreamWriter sw = File.CreateText(Application.StartupPath + "/fadecube_config.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(guiOptionsFile));
            serializer.Serialize(sw, optionsFile);
            sw.Close();
        }
    }

    public class AnimationWithGuiOptions
    {
        public CubeAnimationData AnimationData;
        public guiOptions GuiOptions;

        public AnimationWithGuiOptions(CubeAnimationData AnimationData, guiOptions GuiOptions)
        {
            this.AnimationData = AnimationData;
            this.GuiOptions = GuiOptions;
        }
    }

    public class FormCubeLayerVisualiser
    {
        private Panel dataPanel;
        private PictureBox[] layerData;
        //the upper left coordinate of the LEDlayer
        private Point location;
        private MainForm parentForm;

        public byte[] actualFrameData;
        public int actualLayer = 0;

        private guiOptions GuiOptions;
        public FormCubeLayerVisualiser( Control.ControlCollection parentControl, Point location, guiOptions p_GuiOptions, MainForm mainForm )
        {
            int i = 0;
            this.location = location;
            this.GuiOptions = p_GuiOptions;
            this.dataPanel = new System.Windows.Forms.Panel();
            this.dataPanel.Location = location;
            this.dataPanel.Name = "panel1";
            this.dataPanel.Size = new System.Drawing.Size(320, 320);
            parentControl.Add(dataPanel);            
            layerData = new PictureBox[100];
            this.parentForm = mainForm;

            for (i = 0; i < 100; i++)
            {
                this.layerData[i] = new PictureBox();
                this.layerData[i].Image = global::FadeCube.Properties.Resources.led_0;
                this.layerData[i].Location = new Point((i % 10) * 32, (i / 10) * 32);
                this.layerData[i].Name = "layerData" + i.ToString();
                this.layerData[i].Size = new System.Drawing.Size(32, 32);
                this.layerData[i].TabIndex = 0;
                this.layerData[i].TabStop = false;
                this.layerData[i].SendToBack();
                this.layerData[i].Click += new System.EventHandler(layerData_Click);
                dataPanel.Controls.Add(layerData[i]);
            }
        }

        //when used clicked on the LEDs
        private void layerData_Click(object sender, EventArgs e)
        {
            //computing relative cursor position to calculate the x-y coordinate in the layer
            int x = Cursor.Position.X - (sender as PictureBox).Parent.AccessibilityObject.Bounds.X;
            int y = Cursor.Position.Y - (sender as PictureBox).Parent.AccessibilityObject.Bounds.Y;
            int ledNumberInLayer = ((y / 32) * 10) + (x / 32);
            switch (GuiOptions.selectedBrightness)
            {
                case 0: this.layerData[ledNumberInLayer].Image = global::FadeCube.Properties.Resources.led_0;
                    break;
                case 1: this.layerData[ledNumberInLayer].Image = global::FadeCube.Properties.Resources.led_1;
                    break;
                case 2: this.layerData[ledNumberInLayer].Image = global::FadeCube.Properties.Resources.led_2;
                    break;
                case 3: this.layerData[ledNumberInLayer].Image = global::FadeCube.Properties.Resources.led_3;
                    break;
            }
            actualFrameData[(100 * actualLayer) + ledNumberInLayer] = (byte)GuiOptions.selectedBrightness;

            this.parentForm.handleNetwork();
            GuiOptions.notSaved = true;
        }

        public void updateLayerDisplay()
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                switch (this.actualFrameData[ (100*this.actualLayer) + i ] )
                {
                    case 0: this.layerData[i].Image = global::FadeCube.Properties.Resources.led_0;
                        break;
                    case 1: this.layerData[i].Image = global::FadeCube.Properties.Resources.led_1;
                        break;
                    case 2: this.layerData[i].Image = global::FadeCube.Properties.Resources.led_2;
                        break;
                    case 3: this.layerData[i].Image = global::FadeCube.Properties.Resources.led_3;
                        break;
                }
            }
        }
    }

}

