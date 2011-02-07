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
    public partial class AreYouSureForm : Form
    {
        areYouSureAnswer answer = new areYouSureAnswer();
        public AreYouSureForm(areYouSureAnswer answer)
        {
            this.answer = answer;
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.answer.answer = 1;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.answer.answer = 2;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.answer.answer = 3;
            this.Close();
        }
    }
}
