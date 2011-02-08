using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace FadeCube
{
    public partial class ConnectionsForm : Form
    {
        guiOptions GuiOptions;
        public ConnectionsForm( guiOptions options )
        {
            this.GuiOptions = options;
            InitializeComponent();
        }

        private void ConnectionsForm_Shown(object sender, EventArgs e)
        {
            handleIP1(this.GuiOptions.useEP1);
            if(this.GuiOptions.useEP1)
            {
                ip1CheckBox.Checked = true;
            }
            handleIP2(this.GuiOptions.useEP2);
            if (this.GuiOptions.useEP2)
            {
                ip2CheckBox.Checked = true;
            }
            if (GuiOptions.endPoint1 is IPEndPoint)
            {
                this.ip1TextBox.Text = this.GuiOptions.endPoint1.Address.ToString();
                this.ip1PortTextBox.Text = this.GuiOptions.endPoint1.Port.ToString();
            }
            if (GuiOptions.endPoint2 is IPEndPoint)
            {
                this.ip2TextBox.Text = this.GuiOptions.endPoint2.Address.ToString();
                this.ip2PortTextBox.Text = this.GuiOptions.endPoint2.Port.ToString();
            }
            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }

        private void handleIP1(bool onoff)
        {
            if(onoff)
            {
                ip1Label.Enabled = true;
                ip1TextBox.Enabled = true;
                ip1PortLabel.Enabled = true;
                ip1PortTextBox.Enabled = true;
                btnCheck1.Enabled = true;
            }
            else
            {
                ip1Label.Enabled = false;
                ip1TextBox.Enabled = false;
                ip1PortLabel.Enabled = false;
                ip1PortTextBox.Enabled = false;
                btnCheck1.Enabled = false;
            }
        }

        private void handleIP2(bool onoff)
        {
            if(onoff)
            {
                ip2Label.Enabled = true;
                ip2TextBox.Enabled = true;
                ip2PortLabel.Enabled = true;
                ip2PortTextBox.Enabled = true;
                btnCheck2.Enabled = true;
            }
            else
            {
                ip2Label.Enabled = false;
                ip2TextBox.Enabled = false;
                ip2PortLabel.Enabled = false;
                ip2PortTextBox.Enabled = false;
                btnCheck2.Enabled = false;
            }
        }

        private void ip1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            handleIP1((sender as CheckBox).Checked);
            ip1TextBox.Select();
        }

        private void ip2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            handleIP2((sender as CheckBox).Checked);
            ip2TextBox.Select();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ipTextBox_Leave(object sender, EventArgs e)
        {
            if( !validateIpField( (sender as TextBox).Text ) )
            {
                MessageBox.Show("Not valid IP address");
                //(sender as TextBox).Text = "";
                (sender as TextBox).Select();
            }
        }

        private bool validateIpField(string inputValue)
        {
            IPAddress dummy_ipa;
            if(IPAddress.TryParse(inputValue, out dummy_ipa))
            {
                return true;
            }
            return false;
        }

        private void portTextBox_Leave(object sender, EventArgs e)
        {
            if (!validatePortField((sender as TextBox).Text))
            {
                MessageBox.Show("Not valid port number");
                //(sender as TextBox).Text = "";
                (sender as TextBox).Select();
            }
        }

        private bool validatePortField(string inputValue)
        {
            try
            {
                Int32.Parse(inputValue);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ip1CheckBox.Checked)
            {
                if (validateIpField(ip1TextBox.Text) && validatePortField(ip1PortTextBox.Text))
                {
                    IPAddress ipa = IPAddress.Parse(ip1TextBox.Text);
                    IPEndPoint ipe = new IPEndPoint(ipa, Int32.Parse(ip1PortTextBox.Text));
                    GuiOptions.endPoint1 = ipe;
                    GuiOptions.useEP1 = true;
                }
                else
                {
                    ip1CheckBox.Checked = false;
                    GuiOptions.useEP1 = false;
                }
            }
            else
            {
                GuiOptions.useEP1 = false;
            }
            if (ip2CheckBox.Checked)
            {
                if (validateIpField(ip2TextBox.Text) && validatePortField(ip2PortTextBox.Text))
                {
                    IPAddress ipa = IPAddress.Parse(ip2TextBox.Text);
                    IPEndPoint ipe = new IPEndPoint(ipa, Int32.Parse(ip2PortTextBox.Text));
                    GuiOptions.endPoint2 = ipe;
                    GuiOptions.useEP2 = true;
                }
                else
                {
                    ip2CheckBox.Checked = false;
                    GuiOptions.useEP2 = false;
                }
            }
            else
            {
                GuiOptions.useEP2 = false;
            }
            this.Close();
        }

        private void btnCheck1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( checkDeviceConnection( ip1TextBox.Text, ip1PortTextBox.Text ));
        }

        private string checkDeviceConnection(string ip, string port)
        {
            byte[] data = new byte[1];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), Int32.Parse(port));
            Socket server = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);

            server.SendTo(data, data.Length, SocketFlags.None, ipep);
            IPEndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint tmpRemote = (EndPoint)senderEndPoint;
            data = new byte[30];
            try
            {
                int recv = server.ReceiveFrom(data, ref tmpRemote);
            }
            catch
            {
                return "No answer recieved!";
            }
            return "Device is: " + System.Text.ASCIIEncoding.ASCII.GetString(data);
        }
    }
}
