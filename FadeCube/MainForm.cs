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

namespace FadeCube
{
    public partial class MainForm : Form
    {

        private CubeAnimationData Animation;
        private Point layerDataLocation = new Point( 16, 19 );
        FormCubeLayerVisualiser layerVisulaiser;// = new FormCubeLayerVisualiser();
        string DESTINATION_IP_ADDRESS = "192.168.1.99";
        int DESTINATION_PORT = 1200;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Animation = new CubeAnimationData();
            frameList.DataSource = null;
            frameList.DataSource = Animation.Frames;
            frameList.DisplayMember = "FrameName";
            layerVisulaiser = new FormCubeLayerVisualiser(frameDataGroupBox.Controls, layerDataLocation);
            
            //ugly part, at startup layerVisualiser object does not exists, so event can not assigned in designer
            //but is assigned here, thing has to be made as well here (update textboxes, etc)
            frameList.SelectedIndexChanged += new EventHandler(frameList_SelectedIndexChanged);
            layerVisulaiser.actualFrameData = Animation.Frames[0].FrameData;
            frameNameTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameName;
            frameTimeTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameTime.ToString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (frameNameTextBox.Text != "")
            {
                int frameTime_i = Int16.Parse(frameTimeTextBox.Text);
                CubeAnimation.addFrameToAnimation( Animation, frameNameTextBox.Text, frameTime_i );
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.DisplayMember = "FrameName";
                frameList.SelectedIndex = frameList.Items.Count - 1;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Animation.Frames[frameList.SelectedIndex].FrameData = "bla";
            if ((frameList.SelectedIndex > -1) && (frameList.Items.Count > 1))
            {
                CubeAnimation.removeFrameFromAnimation(Animation, frameList.SelectedIndex);
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.DisplayMember = "FrameName";
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (frameList.SelectedIndex > 0)
            {
                CubeAnimation.moveUpFrameInAnimation(Animation, frameList.SelectedIndex);
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.SelectedIndex = frameList.SelectedIndex - 1;
                frameList.DisplayMember = "FrameName";
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (frameList.SelectedIndex < ( Animation.Frames.Length - 1) )
            {
                CubeAnimation.moveDownFrameInAnimation(Animation, frameList.SelectedIndex);
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.SelectedIndex = frameList.SelectedIndex + 1;
                frameList.DisplayMember = "FrameName";
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Animation.Frames[frameList.SelectedIndex].FrameName = frameNameTextBox.Text;
            frameList.DataSource = null;
            frameList.DataSource = Animation.Frames;
            frameList.DisplayMember = "FrameName";
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animationOpenDialog.ShowDialog();
            if (animationOpenDialog.FileName != "")
            {
                Animation = CubeAnimation.loadAnimation(animationOpenDialog.FileName);
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.DisplayMember = "FrameName";
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animationSaveDialog.ShowDialog();
            if (animationSaveDialog.FileName != "")
            {
                CubeAnimation.saveAnimation(Animation, animationSaveDialog.FileName);
            }
        }

        private void frameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frameList.SelectedIndex > -1)
            {
                frameNameTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameName;
                frameTimeTextBox.Text = Animation.Frames[frameList.SelectedIndex].FrameTime.ToString();
                layerVisulaiser.actualFrameData = Animation.Frames[ frameList.SelectedIndex ].FrameData;
                layerVisulaiser.updateLayerDisplay();
                CubeAnimation.sendFramePacket(DESTINATION_IP_ADDRESS, DESTINATION_PORT, Animation.Frames[frameList.SelectedIndex].FrameData);
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
            layerVisulaiser.actualBrightness = Int16.Parse((sender as RadioButton).Text);
        }

        private void btnFillFrame_Click(object sender, EventArgs e)
        {
            CubeAnimation.fillFrameInAnimation(Animation, frameList.SelectedIndex, layerVisulaiser.actualBrightness);
            layerVisulaiser.updateLayerDisplay();
            CubeAnimation.sendFramePacket(DESTINATION_IP_ADDRESS, DESTINATION_PORT, Animation.Frames[frameList.SelectedIndex].FrameData);
        }

        private void btnFillLayer_Click(object sender, EventArgs e)
        {
            CubeAnimation.fillLayerInAnimation(Animation, frameList.SelectedIndex, layerSelectorTrackBar.Value, layerVisulaiser.actualBrightness);
            layerVisulaiser.updateLayerDisplay();
            CubeAnimation.sendFramePacket(DESTINATION_IP_ADDRESS, DESTINATION_PORT, Animation.Frames[frameList.SelectedIndex].FrameData);
        }

        private void editSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }
    }

    public class FormCubeLayerVisualiser
    {
        private Panel dataPanel;
        private PictureBox[] layerData;
        //the upper left coordinate of the LEDlayer
        private Point location;

        public int actualBrightness = 3;
        public byte[] actualFrameData;
        public int actualLayer = 0;
        public FormCubeLayerVisualiser( Control.ControlCollection parentControl, Point location )
        {
            int i = 0;
            this.location = location;
            this.dataPanel = new System.Windows.Forms.Panel();
            this.dataPanel.Location = location;
            this.dataPanel.Name = "panel1";
            this.dataPanel.Size = new System.Drawing.Size(320, 320);
            parentControl.Add(dataPanel);            
            layerData = new PictureBox[100];

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
            switch (this.actualBrightness)
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
            actualFrameData[(100 * actualLayer) + ledNumberInLayer] = (byte)this.actualBrightness;

            CubeAnimation.sendFramePacket("192.168.1.99", 1200, this.actualFrameData);

//            MessageBox.Show( "x:" + x.ToString() + ", y:" + y.ToString() );
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

    public class CubeAnimation
    {
        public static CubeAnimationData loadAnimation(string path)
        {
            StreamReader sr = File.OpenText(path);
            XmlSerializer serializer = new XmlSerializer(typeof(CubeAnimationData));
            CubeAnimationData animation = (CubeAnimationData)serializer.Deserialize(sr);
            sr.Close();
            return animation;
        }

        public static void saveAnimation(CubeAnimationData animation, string path)
        {
            StreamWriter sw = File.CreateText(path);
            XmlSerializer serializer = new XmlSerializer(typeof(CubeAnimationData));
            serializer.Serialize(sw, animation);
            sw.Close();
        }

        public static void addFrameToAnimation(CubeAnimationData animation, string frameName, int frameTime)
        {
            int i = 0;
            CubeAnimationFrame[] newFrames = new CubeAnimationFrame[animation.Frames.Length + 1];
            for (i = 0; i < animation.Frames.Length; i++)
            {
                newFrames[i] = animation.Frames[i];
            }
            newFrames[i] = new CubeAnimationFrame(frameName, frameTime);
            animation.Frames = newFrames;
        }

        public static void removeFrameFromAnimation(CubeAnimationData animation, int frameNumber)
        {
            int i = 0;
            CubeAnimationFrame[] newFrames = new CubeAnimationFrame[animation.Frames.Length - 1];
            for (i = 0; i < animation.Frames.Length; i++)
            {
                if (i < frameNumber)
                {
                    newFrames[i] = animation.Frames[i];
                }
                else if (i == frameNumber)
                {
                    continue;
                }
                else
                {
                    newFrames[i - 1] = animation.Frames[i];
                }
            }
            animation.Frames = newFrames;
        }

        public static void moveUpFrameInAnimation(CubeAnimationData animation, int frameNumber)
        {
            if (frameNumber > 0)
            {
                CubeAnimationFrame upFrame = animation.Frames[frameNumber - 1];
                CubeAnimationFrame downFrame = animation.Frames[frameNumber];

                animation.Frames[frameNumber] = upFrame;
                animation.Frames[frameNumber - 1] = downFrame;
            }
        }
        public static void moveDownFrameInAnimation(CubeAnimationData animation, int frameNumber)
        {
            if (frameNumber < (animation.Frames.Length - 1) )
            {
                CubeAnimationFrame upFrame = animation.Frames[frameNumber];
                CubeAnimationFrame downFrame = animation.Frames[frameNumber + 1];

                animation.Frames[frameNumber + 1] = upFrame;
                animation.Frames[frameNumber] = downFrame;
            }
        }

        public static void sendFramePacket(string address, int port, byte[] frameData)
        {
            IPAddress destinationIPaddress = IPAddress.Parse(address);
            IPEndPoint ep = new IPEndPoint(destinationIPaddress, port);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            int i = 0;
            byte[] buffer = new byte[250];
            for( i = 0; i < 1000; i++ )
            {
                buffer[i / 4] |=  (byte)(frameData[i] << (2*(3-(i%4))));
            }
            s.SendTo( buffer, ep);
        }
        public static void fillFrameInAnimation(CubeAnimationData animation, int framenumber, int brightness)
        {
            for (int i = 0; i < 1000; i++)
            {
                animation.Frames[framenumber].FrameData[i] = (byte)brightness;
            }
        }
        public static void fillLayerInAnimation(CubeAnimationData animation, int framenumber, int layernumber, int brightness)
        {
            for (int i = 100*layernumber; i < ((100*layernumber)+100); i++)
            {
                animation.Frames[framenumber].FrameData[i] = (byte)brightness;
            }
        }
    }

    public class CubeAnimationData
    {
        private CubeAnimationGlobalOptions globalOptions;
        private CubeAnimationFrame[] frames;

        public CubeAnimationData()
        {
            globalOptions = new CubeAnimationGlobalOptions( "untitled", 50);
            frames = new CubeAnimationFrame[1];
            frames[0] = new CubeAnimationFrame("untitled frame", 50);
        }

        [XmlElement(ElementName = "GlobalOptions")]
        public CubeAnimationGlobalOptions GlobalOptions
        {
            get
            {
                return globalOptions;
            }
            set
            {
                globalOptions = value;
            }
        }
        [XmlArray(ElementName = "Frames")]
        public CubeAnimationFrame[] Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }
    } 

    public class CubeAnimationGlobalOptions
    {
        private string animationName;
        private int frameTime;

        public CubeAnimationGlobalOptions( string animationName, int frameTime )
        {
            this.animationName = animationName;
            this.frameTime = frameTime;
        }
        public CubeAnimationGlobalOptions() { }

        public string AnimationName
        {
            get
            {
                return animationName;
            }
            set
            {
                animationName = value;
            }
        }
        public int FrameTime
        {
            get
            {
                return frameTime;
            }
            set
            {
                frameTime = value;
            }
        }
    }

    public class CubeAnimationFrame
    {
        private string frameName;
        private int frameTime;
        private byte[] frameData = new byte[1000];

        public CubeAnimationFrame(string frameName, int frameTime)
        {
            this.frameName = frameName;
            this.frameTime = frameTime;
        }
        public CubeAnimationFrame() { }

        public string FrameName
        {
            get
            {
                return frameName;
            }
            set
            {
                frameName = value;
            }
        }
        public int FrameTime
        {
            get
            {
                return frameTime;
            }
            set
            {
                frameTime = value;
            }
        }
        public byte[] FrameData
        {
            get
            {
                return frameData;
            }
            set
            {
                frameData = value;
            }
        }
    }
}

