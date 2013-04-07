namespace MultilayerPerceptron
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
            this.textBox_Noise = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar_Noise = new System.Windows.Forms.TrackBar();
            this.label_Noise = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Noise)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Noise
            // 
            this.textBox_Noise.Location = new System.Drawing.Point(315, 27);
            this.textBox_Noise.Name = "textBox_Noise";
            this.textBox_Noise.Size = new System.Drawing.Size(34, 20);
            this.textBox_Noise.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(9, 53);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(340, 340);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainingToolStripMenuItem,
            this.openImageToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1003, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.trainingToolStripMenuItem.Text = "Training";
            this.trainingToolStripMenuItem.Click += new System.EventHandler(this.trainingToolStripMenuItem_Click);
            // 
            // trackBar_Noise
            // 
            this.trackBar_Noise.Location = new System.Drawing.Point(39, 27);
            this.trackBar_Noise.Maximum = 100;
            this.trackBar_Noise.Name = "trackBar_Noise";
            this.trackBar_Noise.Size = new System.Drawing.Size(270, 45);
            this.trackBar_Noise.TabIndex = 3;
            this.trackBar_Noise.TickFrequency = 10;
            this.trackBar_Noise.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_Noise.ValueChanged += new System.EventHandler(this.trackBar_Noise_ValueChanged);
            this.trackBar_Noise.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_Noise_MouseUp);
            // 
            // label_Noise
            // 
            this.label_Noise.AutoSize = true;
            this.label_Noise.Location = new System.Drawing.Point(6, 27);
            this.label_Noise.Name = "label_Noise";
            this.label_Noise.Size = new System.Drawing.Size(34, 13);
            this.label_Noise.TabIndex = 4;
            this.label_Noise.Text = "Noise";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image|*.jpg";
            this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.Multiselect = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 405);
            this.Controls.Add(this.label_Noise);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBox_Noise);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.trackBar_Noise);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "Lab4 - Multilayer Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Noise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Noise;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar_Noise;
        private System.Windows.Forms.Label label_Noise;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

