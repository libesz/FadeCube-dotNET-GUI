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
            frameList.DataSource = Animation.Frames;
            frameList.DisplayMember = "FrameName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (newFrameName.Text != "")
            {
                CubeAnimation.addFrameToAnimation( Animation, newFrameName.Text );
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
                frameList.DataSource = Animation.Frames;
                frameList.DisplayMember = "FrameName";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            animationOpenDialog.ShowDialog();
            Animation = CubeAnimation.loadAnimation(animationOpenDialog.FileName);
            frameList.DataSource = Animation.Frames;
            frameList.DisplayMember = "FrameName";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            animationSaveDialog.ShowDialog();
            CubeAnimation.saveAnimation(Animation, animationSaveDialog.FileName);
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

