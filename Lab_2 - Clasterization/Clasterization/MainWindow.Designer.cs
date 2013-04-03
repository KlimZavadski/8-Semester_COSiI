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
            this.tabPage_Info = new System.Windows.Forms.TabPage();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.tabPage_Classterize = new System.Windows.Forms.TabPage();
            this.textBox_Classterize = new System.Windows.Forms.TextBox();
            this.trackBar_Coeff = new System.Windows.Forms.TrackBar();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Base)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage_Info.SuspendLayout();
            this.tabPage_Classterize.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(865, 24);
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
            this.pictureBox_Result.Size = new System.Drawing.Size(425, 344);
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
            this.tabControl.Controls.Add(this.tabPage_Info);
            this.tabControl.Controls.Add(this.tabPage_Classterize);
            this.tabControl.Location = new System.Drawing.Point(627, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(236, 343);
            this.tabControl.TabIndex = 5;
            // 
            // tabPage_Info
            // 
            this.tabPage_Info.Controls.Add(this.textBox_Info);
            this.tabPage_Info.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Info.Name = "tabPage_Info";
            this.tabPage_Info.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Info.Size = new System.Drawing.Size(228, 317);
            this.tabPage_Info.TabIndex = 0;
            this.tabPage_Info.Text = "Info";
            this.tabPage_Info.UseVisualStyleBackColor = true;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Info.Location = new System.Drawing.Point(6, 6);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(214, 307);
            this.textBox_Info.TabIndex = 0;
            // 
            // tabPage_Classterize
            // 
            this.tabPage_Classterize.Controls.Add(this.textBox_Classterize);
            this.tabPage_Classterize.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Classterize.Name = "tabPage_Classterize";
            this.tabPage_Classterize.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Classterize.Size = new System.Drawing.Size(228, 317);
            this.tabPage_Classterize.TabIndex = 1;
            this.tabPage_Classterize.Text = "Classterize";
            this.tabPage_Classterize.UseVisualStyleBackColor = true;
            // 
            // textBox_Classterize
            // 
            this.textBox_Classterize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Classterize.Location = new System.Drawing.Point(6, 6);
            this.textBox_Classterize.Multiline = true;
            this.textBox_Classterize.Name = "textBox_Classterize";
            this.textBox_Classterize.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Classterize.Size = new System.Drawing.Size(214, 305);
            this.textBox_Classterize.TabIndex = 1;
            // 
            // trackBar_Coeff
            // 
            this.trackBar_Coeff.Location = new System.Drawing.Point(627, -1);
            this.trackBar_Coeff.Maximum = 40;
            this.trackBar_Coeff.Name = "trackBar_Coeff";
            this.trackBar_Coeff.Size = new System.Drawing.Size(187, 45);
            this.trackBar_Coeff.TabIndex = 5;
            this.trackBar_Coeff.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Coeff.Value = 10;
            this.trackBar_Coeff.ValueChanged += new System.EventHandler(this.trackBar_Coeff_ValueChanged);
            // 
            // textBox_Count
            // 
            this.textBox_Count.Location = new System.Drawing.Point(811, 0);
            this.textBox_Count.Multiline = true;
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.Size = new System.Drawing.Size(52, 24);
            this.textBox_Count.TabIndex = 6;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 375);
            this.Controls.Add(this.textBox_Count);
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
            this.tabPage_Info.ResumeLayout(false);
            this.tabPage_Info.PerformLayout();
            this.tabPage_Classterize.ResumeLayout(false);
            this.tabPage_Classterize.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage_Info;
        private System.Windows.Forms.ToolStripMenuItem classterizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar_Coeff;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.TabPage tabPage_Classterize;
        private System.Windows.Forms.TextBox textBox_Classterize;
        private System.Windows.Forms.TextBox textBox_Count;
    }
}