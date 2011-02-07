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
    public partial class AnimationOptionsForm : Form
    {
        CubeAnimationGlobalOptions animationOptions;
        guiOptions GuiOptions;
        public AnimationOptionsForm( guiOptions GuiOptions, CubeAnimationGlobalOptions animationOptions)
        {
            this.GuiOptions = GuiOptions;
            this.animationOptions = animationOptions;
            InitializeComponent();
        }

        private void AnimationOptionsForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = animationOptions.AnimationName;
        }

        private void timeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == MainForm.validateFrameNameField(nameTextBox.Text))
            {
                animationOptions.AnimationName = nameTextBox.Text;
                GuiOptions.notSaved = true;
                this.Close();
            }
        }
    }
}
