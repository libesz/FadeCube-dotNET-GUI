namespace FadeCube
{
    partial class ConnectionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ip1TextBox = new System.Windows.Forms.TextBox();
            this.ip1Label = new System.Windows.Forms.Label();
            this.ip1CheckBox = new System.Windows.Forms.CheckBox();
            this.ip2CheckBox = new System.Windows.Forms.CheckBox();
            this.ip2Label = new System.Windows.Forms.Label();
            this.ip2TextBox = new System.Windows.Forms.TextBox();
            this.ip1PortLabel = new System.Windows.Forms.Label();
            this.ip2PortLabel = new System.Windows.Forms.Label();
            this.ip1PortTextBox = new System.Windows.Forms.TextBox();
            this.ip2PortTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.btnCheck1 = new System.Windows.Forms.Button();
            this.btnCheck2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip1TextBox
            // 
            this.ip1TextBox.Location = new System.Drawing.Point(155, 8);
            this.ip1TextBox.Name = "ip1TextBox";
            this.ip1TextBox.Size = new System.Drawing.Size(100, 20);
            this.ip1TextBox.TabIndex = 1;
            this.ip1TextBox.Leave += new System.EventHandler(this.ipTextBox_Leave);
            // 
            // ip1Label
            // 
            this.ip1Label.AutoSize = true;
            this.ip1Label.Location = new System.Drawing.Point(91, 12);
            this.ip1Label.Name = "ip1Label";
            this.ip1Label.Size = new System.Drawing.Size(58, 13);
            this.ip1Label.TabIndex = 1;
            this.ip1Label.Text = "IP Address";
            // 
            // ip1CheckBox
            // 
            this.ip1CheckBox.AutoSize = true;
            this.ip1CheckBox.Location = new System.Drawing.Point(12, 11);
            this.ip1CheckBox.Name = "ip1CheckBox";
            this.ip1CheckBox.Size = new System.Drawing.Size(60, 17);
            this.ip1CheckBox.TabIndex = 0;
            this.ip1CheckBox.Text = "Primary";
            this.ip1CheckBox.UseVisualStyleBackColor = true;
            this.ip1CheckBox.CheckedChanged += new System.EventHandler(this.ip1CheckBox_CheckedChanged);
            // 
            // ip2CheckBox
            // 
            this.ip2CheckBox.AutoSize = true;
            this.ip2CheckBox.Location = new System.Drawing.Point(12, 37);
            this.ip2CheckBox.Name = "ip2CheckBox";
            this.ip2CheckBox.Size = new System.Drawing.Size(77, 17);
            this.ip2CheckBox.TabIndex = 3;
            this.ip2CheckBox.Text = "Secondary";
            this.ip2CheckBox.UseVisualStyleBackColor = true;
            this.ip2CheckBox.CheckedChanged += new System.EventHandler(this.ip2CheckBox_CheckedChanged);
            // 
            // ip2Label
            // 
            this.ip2Label.AutoSize = true;
            this.ip2Label.Location = new System.Drawing.Point(91, 38);
            this.ip2Label.Name = "ip2Label";
            this.ip2Label.Size = new System.Drawing.Size(58, 13);
            this.ip2Label.TabIndex = 4;
            this.ip2Label.Text = "IP Address";
            // 
            // ip2TextBox
            // 
            this.ip2TextBox.Location = new System.Drawing.Point(155, 34);
            this.ip2TextBox.Name = "ip2TextBox";
            this.ip2TextBox.Size = new System.Drawing.Size(100, 20);
            this.ip2TextBox.TabIndex = 4;
            this.ip2TextBox.Leave += new System.EventHandler(this.ipTextBox_Leave);
            // 
            // ip1PortLabel
            // 
            this.ip1PortLabel.AutoSize = true;
            this.ip1PortLabel.Location = new System.Drawing.Point(274, 12);
            this.ip1PortLabel.Name = "ip1PortLabel";
            this.ip1PortLabel.Size = new System.Drawing.Size(26, 13);
            this.ip1PortLabel.TabIndex = 6;
            this.ip1PortLabel.Text = "Port";
            // 
            // ip2PortLabel
            // 
            this.ip2PortLabel.AutoSize = true;
            this.ip2PortLabel.Location = new System.Drawing.Point(274, 38);
            this.ip2PortLabel.Name = "ip2PortLabel";
            this.ip2PortLabel.Size = new System.Drawing.Size(26, 13);
            this.ip2PortLabel.TabIndex = 7;
            this.ip2PortLabel.Text = "Port";
            // 
            // ip1PortTextBox
            // 
            this.ip1PortTextBox.Location = new System.Drawing.Point(306, 8);
            this.ip1PortTextBox.Name = "ip1PortTextBox";
            this.ip1PortTextBox.Size = new System.Drawing.Size(55, 20);
            this.ip1PortTextBox.TabIndex = 2;
            this.ip1PortTextBox.Leave += new System.EventHandler(this.portTextBox_Leave);
            // 
            // ip2PortTextBox
            // 
            this.ip2PortTextBox.Location = new System.Drawing.Point(306, 34);
            this.ip2PortTextBox.Name = "ip2PortTextBox";
            this.ip2PortTextBox.Size = new System.Drawing.Size(55, 20);
            this.ip2PortTextBox.TabIndex = 6;
            this.ip2PortTextBox.Leave += new System.EventHandler(this.portTextBox_Leave);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(226, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(244, 67);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(199, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // btnCheck1
            // 
            this.btnCheck1.Location = new System.Drawing.Point(382, 7);
            this.btnCheck1.Name = "btnCheck1";
            this.btnCheck1.Size = new System.Drawing.Size(63, 23);
            this.btnCheck1.TabIndex = 9;
            this.btnCheck1.Text = "Check";
            this.btnCheck1.UseVisualStyleBackColor = true;
            this.btnCheck1.Click += new System.EventHandler(this.btnCheck1_Click);
            // 
            // btnCheck2
            // 
            this.btnCheck2.Location = new System.Drawing.Point(382, 33);
            this.btnCheck2.Name = "btnCheck2";
            this.btnCheck2.Size = new System.Drawing.Size(63, 23);
            this.btnCheck2.TabIndex = 10;
            this.btnCheck2.Text = "Check";
            this.btnCheck2.UseVisualStyleBackColor = true;
            // 
            // ConnectionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(455, 100);
            this.Controls.Add(this.btnCheck2);
            this.Controls.Add(this.btnCheck1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.ip2PortTextBox);
            this.Controls.Add(this.ip1PortTextBox);
            this.Controls.Add(this.ip2PortLabel);
            this.Controls.Add(this.ip1PortLabel);
            this.Controls.Add(this.ip2CheckBox);
            this.Controls.Add(this.ip2Label);
            this.Controls.Add(this.ip2TextBox);
            this.Controls.Add(this.ip1CheckBox);
            this.Controls.Add(this.ip1Label);
            this.Controls.Add(this.ip1TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionsForm";
            this.ShowIcon = false;
            this.Text = "Connection settings";
            this.Shown += new System.EventHandler(this.ConnectionsForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip1TextBox;
        private System.Windows.Forms.Label ip1Label;
        private System.Windows.Forms.CheckBox ip1CheckBox;
        private System.Windows.Forms.CheckBox ip2CheckBox;
        private System.Windows.Forms.Label ip2Label;
        private System.Windows.Forms.TextBox ip2TextBox;
        private System.Windows.Forms.Label ip1PortLabel;
        private System.Windows.Forms.Label ip2PortLabel;
        private System.Windows.Forms.TextBox ip1PortTextBox;
        private System.Windows.Forms.TextBox ip2PortTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button btnCheck1;
        private System.Windows.Forms.Button btnCheck2;
    }
}