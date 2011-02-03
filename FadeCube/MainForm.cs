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

namespace FadeCube
{
    public partial class MainForm : Form
    {
        public CubeAnimationData Animation;
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
            if (FrameName.Text != "")
            {
                CubeAnimation.addFrameToAnimation( Animation, FrameName.Text );
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.DisplayMember = "FrameName";
                frameList.SelectedIndex = frameList.Items.Count - 1;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Animation.Frames[frameList.SelectedIndex].FrameData = "bla";
            if (frameList.SelectedIndex > -1)
            {
                CubeAnimation.removeFrameFromAnimation(Animation, frameList.SelectedIndex);
                frameList.DataSource = null;
                frameList.DataSource = Animation.Frames;
                frameList.DisplayMember = "FrameName";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            animationSaveDialog.ShowDialog();
            if (animationSaveDialog.FileName != "")
            {
                CubeAnimation.saveAnimation(Animation, animationSaveDialog.FileName);
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

        private void btnRename_Click(object sender, EventArgs e)
        {
            Animation.Frames[frameList.SelectedIndex].FrameName = FrameName.Text;
            frameList.DataSource = null;
            frameList.DataSource = Animation.Frames;
            frameList.DisplayMember = "FrameName";
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

        public static void addFrameToAnimation(CubeAnimationData animation, string frameName)
        {
            int i = 0;
            CubeAnimationFrame[] newFrames = new CubeAnimationFrame[animation.Frames.Length + 1];
            for (i = 0; i < animation.Frames.Length; i++)
            {
                newFrames[i] = animation.Frames[i];
            }
            newFrames[i] = new CubeAnimationFrame(frameName, 50);
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
        private string frameData;

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
        public string FrameData
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

