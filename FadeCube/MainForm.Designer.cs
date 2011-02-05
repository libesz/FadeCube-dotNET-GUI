namespace FadeCube
{
    partial class MainForm
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
            this.frameList = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.frameNameTextBox = new System.Windows.Forms.TextBox();
            this.animationOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.animationSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameNameLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.frameListGroupBox = new System.Windows.Forms.GroupBox();
            this.frameOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.frameTimeLabel = new System.Windows.Forms.Label();
            this.frameTimeTextBox = new System.Windows.Forms.TextBox();
            this.frameDataGroupBox = new System.Windows.Forms.GroupBox();
            this.btnFillLayer = new System.Windows.Forms.Button();
            this.btnFillFrame = new System.Windows.Forms.Button();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.brightnessRadio3 = new System.Windows.Forms.RadioButton();
            this.brightnessRadio2 = new System.Windows.Forms.RadioButton();
            this.brightnessRadio1 = new System.Windows.Forms.RadioButton();
            this.brightnessRadio0 = new System.Windows.Forms.RadioButton();
            this.selectedLayerLabel2 = new System.Windows.Forms.Label();
            this.selectedLayerLabel1 = new System.Windows.Forms.Label();
            this.layerSelectorTrackBar = new System.Windows.Forms.TrackBar();
            this.animationOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.frameListGroupBox.SuspendLayout();
            this.frameOptionsGroupBox.SuspendLayout();
            this.frameDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerSelectorTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // frameList
            // 
            this.frameList.Location = new System.Drawing.Point(6, 21);
            this.frameList.Name = "frameList";
            this.frameList.Size = new System.Drawing.Size(120, 199);
            this.frameList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(188, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(132, 196);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frameNameTextBox
            // 
            this.frameNameTextBox.Location = new System.Drawing.Point(77, 24);
            this.frameNameTextBox.Name = "frameNameTextBox";
            this.frameNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.frameNameTextBox.TabIndex = 3;
            // 
            // animationSaveDialog
            // 
            this.animationSaveDialog.DefaultExt = "xml";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(132, 21);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 24);
            this.btnMoveUp.TabIndex = 6;
            this.btnMoveUp.Text = "Move up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(132, 51);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 24);
            this.btnMoveDown.TabIndex = 7;
            this.btnMoveDown.Text = "Move down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(9, 105);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(188, 26);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "Modify selected";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Location = new System.Drawing.Point(9, 137);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(188, 26);
            this.btnDuplicate.TabIndex = 9;
            this.btnDuplicate.Text = "Duplicate selected";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionsToolStripMenuItem,
            this.animationOptionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.connectionsToolStripMenuItem.Text = "Connections";
            this.connectionsToolStripMenuItem.Click += new System.EventHandler(this.editSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // frameNameLabel
            // 
            this.frameNameLabel.AutoSize = true;
            this.frameNameLabel.Location = new System.Drawing.Point(6, 27);
            this.frameNameLabel.Name = "frameNameLabel";
            this.frameNameLabel.Size = new System.Drawing.Size(68, 13);
            this.frameNameLabel.TabIndex = 12;
            this.frameNameLabel.Text = "Frame name:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(593, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.StatusLabel1.Text = "FadeCube GUI started up!";
            // 
            // frameListGroupBox
            // 
            this.frameListGroupBox.Controls.Add(this.btnMoveDown);
            this.frameListGroupBox.Controls.Add(this.btnMoveUp);
            this.frameListGroupBox.Controls.Add(this.btnRemove);
            this.frameListGroupBox.Controls.Add(this.frameList);
            this.frameListGroupBox.Location = new System.Drawing.Point(12, 27);
            this.frameListGroupBox.Name = "frameListGroupBox";
            this.frameListGroupBox.Size = new System.Drawing.Size(215, 230);
            this.frameListGroupBox.TabIndex = 14;
            this.frameListGroupBox.TabStop = false;
            this.frameListGroupBox.Text = "Framelist";
            // 
            // frameOptionsGroupBox
            // 
            this.frameOptionsGroupBox.Controls.Add(this.frameTimeLabel);
            this.frameOptionsGroupBox.Controls.Add(this.frameTimeTextBox);
            this.frameOptionsGroupBox.Controls.Add(this.frameNameLabel);
            this.frameOptionsGroupBox.Controls.Add(this.btnDuplicate);
            this.frameOptionsGroupBox.Controls.Add(this.frameNameTextBox);
            this.frameOptionsGroupBox.Controls.Add(this.btnAdd);
            this.frameOptionsGroupBox.Controls.Add(this.btnModify);
            this.frameOptionsGroupBox.Location = new System.Drawing.Point(12, 263);
            this.frameOptionsGroupBox.Name = "frameOptionsGroupBox";
            this.frameOptionsGroupBox.Size = new System.Drawing.Size(215, 178);
            this.frameOptionsGroupBox.TabIndex = 15;
            this.frameOptionsGroupBox.TabStop = false;
            this.frameOptionsGroupBox.Text = "Frame options";
            // 
            // frameTimeLabel
            // 
            this.frameTimeLabel.AutoSize = true;
            this.frameTimeLabel.Location = new System.Drawing.Point(6, 50);
            this.frameTimeLabel.Name = "frameTimeLabel";
            this.frameTimeLabel.Size = new System.Drawing.Size(115, 13);
            this.frameTimeLabel.TabIndex = 14;
            this.frameTimeLabel.Text = "Frame visible time (ms):";
            // 
            // frameTimeTextBox
            // 
            this.frameTimeTextBox.Location = new System.Drawing.Point(127, 47);
            this.frameTimeTextBox.MaxLength = 5;
            this.frameTimeTextBox.Name = "frameTimeTextBox";
            this.frameTimeTextBox.Size = new System.Drawing.Size(70, 20);
            this.frameTimeTextBox.TabIndex = 13;
            // 
            // frameDataGroupBox
            // 
            this.frameDataGroupBox.Controls.Add(this.btnFillLayer);
            this.frameDataGroupBox.Controls.Add(this.btnFillFrame);
            this.frameDataGroupBox.Controls.Add(this.brightnessLabel);
            this.frameDataGroupBox.Controls.Add(this.brightnessRadio3);
            this.frameDataGroupBox.Controls.Add(this.brightnessRadio2);
            this.frameDataGroupBox.Controls.Add(this.brightnessRadio1);
            this.frameDataGroupBox.Controls.Add(this.brightnessRadio0);
            this.frameDataGroupBox.Controls.Add(this.selectedLayerLabel2);
            this.frameDataGroupBox.Controls.Add(this.selectedLayerLabel1);
            this.frameDataGroupBox.Controls.Add(this.layerSelectorTrackBar);
            this.frameDataGroupBox.Location = new System.Drawing.Point(233, 27);
            this.frameDataGroupBox.Name = "frameDataGroupBox";
            this.frameDataGroupBox.Size = new System.Drawing.Size(349, 443);
            this.frameDataGroupBox.TabIndex = 16;
            this.frameDataGroupBox.TabStop = false;
            this.frameDataGroupBox.Text = "Frame data";
            // 
            // btnFillLayer
            // 
            this.btnFillLayer.Location = new System.Drawing.Point(186, 410);
            this.btnFillLayer.Name = "btnFillLayer";
            this.btnFillLayer.Size = new System.Drawing.Size(157, 23);
            this.btnFillLayer.TabIndex = 10;
            this.btnFillLayer.Text = "Fill layer";
            this.btnFillLayer.UseVisualStyleBackColor = true;
            this.btnFillLayer.Click += new System.EventHandler(this.btnFillLayer_Click);
            // 
            // btnFillFrame
            // 
            this.btnFillFrame.Location = new System.Drawing.Point(6, 410);
            this.btnFillFrame.Name = "btnFillFrame";
            this.btnFillFrame.Size = new System.Drawing.Size(157, 23);
            this.btnFillFrame.TabIndex = 9;
            this.btnFillFrame.Text = "Fill frame";
            this.btnFillFrame.UseVisualStyleBackColor = true;
            this.btnFillFrame.Click += new System.EventHandler(this.btnFillFrame_Click);
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(127, 389);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(59, 13);
            this.brightnessLabel.TabIndex = 8;
            this.brightnessLabel.Text = "Brightness:";
            // 
            // brightnessRadio3
            // 
            this.brightnessRadio3.AutoSize = true;
            this.brightnessRadio3.Checked = true;
            this.brightnessRadio3.Location = new System.Drawing.Point(302, 387);
            this.brightnessRadio3.Name = "brightnessRadio3";
            this.brightnessRadio3.Size = new System.Drawing.Size(31, 17);
            this.brightnessRadio3.TabIndex = 7;
            this.brightnessRadio3.TabStop = true;
            this.brightnessRadio3.Text = "3";
            this.brightnessRadio3.UseVisualStyleBackColor = true;
            this.brightnessRadio3.CheckedChanged += new System.EventHandler(this.brightnessRadio_Changed);
            // 
            // brightnessRadio2
            // 
            this.brightnessRadio2.AutoSize = true;
            this.brightnessRadio2.Location = new System.Drawing.Point(265, 387);
            this.brightnessRadio2.Name = "brightnessRadio2";
            this.brightnessRadio2.Size = new System.Drawing.Size(31, 17);
            this.brightnessRadio2.TabIndex = 6;
            this.brightnessRadio2.Text = "2";
            this.brightnessRadio2.UseVisualStyleBackColor = true;
            this.brightnessRadio2.CheckedChanged += new System.EventHandler(this.brightnessRadio_Changed);
            // 
            // brightnessRadio1
            // 
            this.brightnessRadio1.AutoSize = true;
            this.brightnessRadio1.Location = new System.Drawing.Point(229, 387);
            this.brightnessRadio1.Name = "brightnessRadio1";
            this.brightnessRadio1.Size = new System.Drawing.Size(31, 17);
            this.brightnessRadio1.TabIndex = 5;
            this.brightnessRadio1.Text = "1";
            this.brightnessRadio1.UseVisualStyleBackColor = true;
            this.brightnessRadio1.CheckedChanged += new System.EventHandler(this.brightnessRadio_Changed);
            // 
            // brightnessRadio0
            // 
            this.brightnessRadio0.AutoSize = true;
            this.brightnessRadio0.Location = new System.Drawing.Point(192, 387);
            this.brightnessRadio0.Name = "brightnessRadio0";
            this.brightnessRadio0.Size = new System.Drawing.Size(31, 17);
            this.brightnessRadio0.TabIndex = 4;
            this.brightnessRadio0.Text = "0";
            this.brightnessRadio0.UseVisualStyleBackColor = true;
            this.brightnessRadio0.CheckedChanged += new System.EventHandler(this.brightnessRadio_Changed);
            // 
            // selectedLayerLabel2
            // 
            this.selectedLayerLabel2.AutoSize = true;
            this.selectedLayerLabel2.Location = new System.Drawing.Point(84, 389);
            this.selectedLayerLabel2.Name = "selectedLayerLabel2";
            this.selectedLayerLabel2.Size = new System.Drawing.Size(13, 13);
            this.selectedLayerLabel2.TabIndex = 3;
            this.selectedLayerLabel2.Text = "1";
            // 
            // selectedLayerLabel1
            // 
            this.selectedLayerLabel1.AutoSize = true;
            this.selectedLayerLabel1.Location = new System.Drawing.Point(6, 389);
            this.selectedLayerLabel1.Name = "selectedLayerLabel1";
            this.selectedLayerLabel1.Size = new System.Drawing.Size(77, 13);
            this.selectedLayerLabel1.TabIndex = 2;
            this.selectedLayerLabel1.Text = "Selected layer:";
            // 
            // layerSelectorTrackBar
            // 
            this.layerSelectorTrackBar.Location = new System.Drawing.Point(9, 341);
            this.layerSelectorTrackBar.Maximum = 9;
            this.layerSelectorTrackBar.Name = "layerSelectorTrackBar";
            this.layerSelectorTrackBar.Size = new System.Drawing.Size(331, 32);
            this.layerSelectorTrackBar.TabIndex = 1;
            this.layerSelectorTrackBar.Scroll += new System.EventHandler(this.layerSelectorTrackBar_Scroll);
            // 
            // animationOptionsToolStripMenuItem
            // 
            this.animationOptionsToolStripMenuItem.Name = "animationOptionsToolStripMenuItem";
            this.animationOptionsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.animationOptionsToolStripMenuItem.Text = "Animation options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 497);
            this.Controls.Add(this.frameDataGroupBox);
            this.Controls.Add(this.frameOptionsGroupBox);
            this.Controls.Add(this.frameListGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FadeCube GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.frameListGroupBox.ResumeLayout(false);
            this.frameOptionsGroupBox.ResumeLayout(false);
            this.frameOptionsGroupBox.PerformLayout();
            this.frameDataGroupBox.ResumeLayout(false);
            this.frameDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerSelectorTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox frameList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox frameNameTextBox;
        private System.Windows.Forms.OpenFileDialog animationOpenDialog;
        private System.Windows.Forms.SaveFileDialog animationSaveDialog;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label frameNameLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.GroupBox frameListGroupBox;
        private System.Windows.Forms.GroupBox frameOptionsGroupBox;
        private System.Windows.Forms.Label frameTimeLabel;
        private System.Windows.Forms.TextBox frameTimeTextBox;
        private System.Windows.Forms.GroupBox frameDataGroupBox;
        private System.Windows.Forms.TrackBar layerSelectorTrackBar;
        private System.Windows.Forms.Label selectedLayerLabel2;
        private System.Windows.Forms.Label selectedLayerLabel1;
        private System.Windows.Forms.RadioButton brightnessRadio0;
        private System.Windows.Forms.RadioButton brightnessRadio1;
        private System.Windows.Forms.RadioButton brightnessRadio3;
        private System.Windows.Forms.RadioButton brightnessRadio2;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Button btnFillLayer;
        private System.Windows.Forms.Button btnFillFrame;
        private System.Windows.Forms.ToolStripMenuItem animationOptionsToolStripMenuItem;
    }
}

