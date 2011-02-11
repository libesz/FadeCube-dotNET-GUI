using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms.Layout;
using System.Net;
using System.Net.Sockets;

namespace FadeCube
{
    public class CubeAnimation
    {
        public static CubeAnimationData loadAnimation(string path)
        {
            try
            {
                StreamReader sr = File.OpenText(path);
                XmlSerializer serializer = new XmlSerializer(typeof(CubeAnimationData));
                CubeAnimationData animation = (CubeAnimationData)serializer.Deserialize(sr);
                sr.Close();
                return animation;
            }
            catch
            {
                return null;
            }
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

        public static void duplicateFrameInAnimation(CubeAnimationData animation, int frameNumber, string frameName, int frameTime)
        {
            int i = 0;
            CubeAnimationFrame[] newFrames = new CubeAnimationFrame[animation.Frames.Length + 1];
            for (i = 0; i < animation.Frames.Length; i++)
            {
                newFrames[i] = animation.Frames[i];
            }
            newFrames[i] = new CubeAnimationFrame();
            newFrames[i].FrameData = (byte[])animation.Frames[frameNumber].FrameData.Clone();
            newFrames[i].FrameName = frameName.Clone().ToString();
            newFrames[i].FrameTime = frameTime;

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
            if (frameNumber < (animation.Frames.Length - 1))
            {
                CubeAnimationFrame upFrame = animation.Frames[frameNumber];
                CubeAnimationFrame downFrame = animation.Frames[frameNumber + 1];

                animation.Frames[frameNumber + 1] = upFrame;
                animation.Frames[frameNumber] = downFrame;
            }
        }

        public static void sendFramePacket(IPEndPoint ep, byte[] frameData)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            int i = 0;
            byte[] buffer = new byte[251];
            buffer[0] = 1;
            for (i = 0; i < 1000; i++)
            {
                buffer[1 + (i / 4) ] |= (byte)(frameData[i] << (2 * (3 - (i % 4))));
            }
            s.SendTo(buffer, ep);
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
            for (int i = 100 * layernumber; i < ((100 * layernumber) + 100); i++)
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
            globalOptions = new CubeAnimationGlobalOptions("untitled", 50);
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

        public CubeAnimationGlobalOptions(string animationName, int frameTime)
        {
            this.animationName = animationName;
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
