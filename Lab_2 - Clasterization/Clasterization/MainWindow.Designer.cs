namespace Clasterization
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classterizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.pictureBox_Result = new System.Windows.Forms.PictureBox();
            this.pictureBox_Base = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1_Classterize = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2_Info = new System.Windows.Forms.TabPage();
            this.trackBar_Coeff = new System.Windows.Forms.TrackBar();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Base)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1_Classterize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Coeff)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.classterizeToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(783, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "MenuStrip";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.processingToolStripMenuItem.Text = "Binarize";
            this.processingToolStripMenuItem.Click += new System.EventHandler(this.binarizeToolStripMenuItem_Click);
            // 
            // classterizeToolStripMenuItem
            // 
            this.classterizeToolStripMenuItem.Name = "classterizeToolStripMenuItem";
            this.classterizeToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.classterizeToolStripMenuItem.Text = "Classterize";
            this.classterizeToolStripMenuItem.Click += new System.EventHandler(this.classterizeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "images|*.jpg";
            this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.InitialDirectory = "D:\\1\\Images\\";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(0, 27);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0;
            this.zedGraphControl.ScrollMaxX = 0;
            this.zedGraphControl.ScrollMaxY = 0;
            this.zedGraphControl.ScrollMaxY2 = 0;
            this.zedGraphControl.ScrollMinX = 0;
            this.zedGraphControl.ScrollMinY = 0;
            this.zedGraphControl.ScrollMinY2 = 0;
            this.zedGraphControl.Size = new System.Drawing.Size(190, 187);
            this.zedGraphControl.TabIndex = 2;
            // 
            // pictureBox_Result
            // 
            this.pictureBox_Result.Location = new System.Drawing.Point(196, 27);
            this.pictureBox_Result.Name = "pictureBox_Result";
            this.pictureBox_Result.Size = new System.Drawing.Size(344, 344);
            this.pictureBox_Result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Result.TabIndex = 3;
            this.pictureBox_Result.TabStop = false;
            // 
            // pictureBox_Base
            // 
            this.pictureBox_Base.Location = new System.Drawing.Point(0, 220);
            this.pictureBox_Base.Name = "pictureBox_Base";
            this.pictureBox_Base.Size = new System.Drawing.Size(190, 151);
            this.pictureBox_Base.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Base.TabIndex = 4;
            this.pictureBox_Base.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1_Classterize);
            this.tabControl.Controls.Add(this.tabPage2_Info);
            this.tabControl.Location = new System.Drawing.Point(547, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(236, 343);
            this.tabControl.TabIndex = 5;
            // 
            // tabPage1_Classterize
            // 
            this.tabPage1_Classterize.Controls.Add(this.label1);
            this.tabPage1_Classterize.Controls.Add(this.pictureBox1);
            this.tabPage1_Classterize.Location = new System.Drawing.Point(4, 22);
            this.tabPage1_Classterize.Name = "tabPage1_Classterize";
            this.tabPage1_Classterize.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1_Classterize.Size = new System.Drawing.Size(228, 317);
            this.tabPage1_Classterize.TabIndex = 0;
            this.tabPage1_Classterize.Text = "tabPage1";
            this.tabPage1_Classterize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2_Info
            // 
            this.tabPage2_Info.Location = new System.Drawing.Point(4, 22);
            this.tabPage2_Info.Name = "tabPage2_Info";
            this.tabPage2_Info.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2_Info.Size = new System.Drawing.Size(228, 317);
            this.tabPage2_Info.TabIndex = 1;
            this.tabPage2_Info.Text = "tabPage2";
            this.tabPage2_Info.UseVisualStyleBackColor = true;
            // 
            // trackBar_Coeff
            // 
            this.trackBar_Coeff.Location = new System.Drawing.Point(547, 0);
            this.trackBar_Coeff.Maximum = 40;
            this.trackBar_Coeff.Name = "trackBar_Coeff";
            this.trackBar_Coeff.Size = new System.Drawing.Size(236, 45);
            this.trackBar_Coeff.TabIndex = 5;
            this.trackBar_Coeff.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Coeff.Value = 10;
            this.trackBar_Coeff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Coeff_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 375);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.trackBar_Coeff);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.pictureBox_Base);
            this.Controls.Add(this.pictureBox_Result);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Base)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1_Classterize.ResumeLayout(false);
            this.tabPage1_Classterize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Coeff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.PictureBox pictureBox_Result;
        private System.Windows.Forms.PictureBox pictureBox_Base;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1_Classterize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2_Info;
        private System.Windows.Forms.ToolStripMenuItem classterizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar_Coeff;
    }
}