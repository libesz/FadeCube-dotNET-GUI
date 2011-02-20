namespace FadeCube
{
    partial class AreYouSureForm
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
            this.areYouSureLabel1 = new System.Windows.Forms.Label();
            this.areYouSureLabel2 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // areYouSureLabel1
            // 
            this.areYouSureLabel1.AutoSize = true;
            this.areYouSureLabel1.Location = new System.Drawing.Point(12, 9);
            this.areYouSureLabel1.Name = "areYouSureLabel1";
            this.areYouSureLabel1.Size = new System.Drawing.Size(144, 13);
            this.areYouSureLabel1.TabIndex = 0;
            this.areYouSureLabel1.Text = "You have unsaved changes!";
            // 
            // areYouSureLabel2
            // 
            this.areYouSureLabel2.AutoSize = true;
            this.areYouSureLabel2.Location = new System.Drawing.Point(12, 22);
            this.areYouSureLabel2.Name = "areYouSureLabel2";
            this.areYouSureLabel2.Size = new System.Drawing.Size(239, 13);
            this.areYouSureLabel2.TabIndex = 1;
            this.areYouSureLabel2.Text = "Do you want to save it, before closing animation?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(12, 41);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(93, 41);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(174, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AreYouSureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 76);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.areYouSureLabel2);
            this.Controls.Add(this.areYouSureLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreYouSureForm";
            this.ShowIcon = false;
            this.Text = "Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label areYouSureLabel1;
        private System.Windows.Forms.Label areYouSureLabel2;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnCancel;
    }
}