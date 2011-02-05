namespace FadeCube
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ip1PortLabel = new System.Windows.Forms.Label();
            this.ip2PortLabel = new System.Windows.Forms.Label();
            this.ip1PortTextBox = new System.Windows.Forms.TextBox();
            this.ip2PortTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip1TextBox
            // 
            this.ip1TextBox.Location = new System.Drawing.Point(155, 8);
            this.ip1TextBox.Name = "ip1TextBox";
            this.ip1TextBox.Size = new System.Drawing.Size(100, 20);
            this.ip1TextBox.TabIndex = 0;
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
            this.ip1CheckBox.TabIndex = 2;
            this.ip1CheckBox.Text = "Primary";
            this.ip1CheckBox.UseVisualStyleBackColor = true;
            // 
            // ip2CheckBox
            // 
            this.ip2CheckBox.AutoSize = true;
            this.ip2CheckBox.Location = new System.Drawing.Point(12, 37);
            this.ip2CheckBox.Name = "ip2CheckBox";
            this.ip2CheckBox.Size = new System.Drawing.Size(77, 17);
            this.ip2CheckBox.TabIndex = 5;
            this.ip2CheckBox.Text = "Secondary";
            this.ip2CheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
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
            this.ip1PortTextBox.TabIndex = 8;
            // 
            // ip2PortTextBox
            // 
            this.ip2PortTextBox.Location = new System.Drawing.Point(306, 34);
            this.ip2PortTextBox.Name = "ip2PortTextBox";
            this.ip2PortTextBox.Size = new System.Drawing.Size(55, 20);
            this.ip2PortTextBox.TabIndex = 9;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(166, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(196, 67);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(166, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 102);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.ip2PortTextBox);
            this.Controls.Add(this.ip1PortTextBox);
            this.Controls.Add(this.ip2PortLabel);
            this.Controls.Add(this.ip1PortLabel);
            this.Controls.Add(this.ip2CheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ip1CheckBox);
            this.Controls.Add(this.ip1Label);
            this.Controls.Add(this.ip1TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip1TextBox;
        private System.Windows.Forms.Label ip1Label;
        private System.Windows.Forms.CheckBox ip1CheckBox;
        private System.Windows.Forms.CheckBox ip2CheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ip1PortLabel;
        private System.Windows.Forms.Label ip2PortLabel;
        private System.Windows.Forms.TextBox ip1PortTextBox;
        private System.Windows.Forms.TextBox ip2PortTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}