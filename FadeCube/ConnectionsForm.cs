using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void handleIP1(bool onoff)
        {
            if(onoff)
            {
                ip1Label.Enabled = true;
                ip1TextBox.Enabled = true;
                ip1PortLabel.Enabled = true;
                ip1PortTextBox.Enabled = true;
            }
            else
            {
                ip1Label.Enabled = false;
                ip1TextBox.Enabled = false;
                ip1PortLabel.Enabled = false;
                ip1PortTextBox.Enabled = false;
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
            }
            else
            {
                ip2Label.Enabled = false;
                ip2TextBox.Enabled = false;
                ip2PortLabel.Enabled = false;
                ip2PortTextBox.Enabled = false;
            }
        }

        private void ip1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            handleIP1((sender as CheckBox).Checked);
        }

        private void ip2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            handleIP2((sender as CheckBox).Checked);
        }
    }
}
