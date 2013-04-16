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
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar_Noise = new System.Windows.Forms.TrackBar();
            this.label_Noise = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox_Class1 = new System.Windows.Forms.PictureBox();
            this.textBox_Class1 = new System.Windows.Forms.TextBox();
            this.textBox_Class2 = new System.Windows.Forms.TextBox();
            this.pictureBox_Class2 = new System.Windows.Forms.PictureBox();
            this.textBox_Class3 = new System.Windows.Forms.TextBox();
            this.pictureBox_Class3 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_Cycles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Noise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Noise
            // 
            this.textBox_Noise.Location = new System.Drawing.Point(245, 27);
            this.textBox_Noise.Name = "textBox_Noise";
            this.textBox_Noise.Size = new System.Drawing.Size(34, 20);
            this.textBox_Noise.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(9, 53);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(270, 270);
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
            this.menuStrip.Size = new System.Drawing.Size(351, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.trainingToolStripMenuItem.Text = "Training";
            this.trainingToolStripMenuItem.Click += new System.EventHandler(this.trainingToolStripMenuItem_Click);
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // trackBar_Noise
            // 
            this.trackBar_Noise.Location = new System.Drawing.Point(39, 27);
            this.trackBar_Noise.Maximum = 100;
            this.trackBar_Noise.Name = "trackBar_Noise";
            this.trackBar_Noise.Size = new System.Drawing.Size(200, 45);
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
            this.openFileDialog.InitialDirectory = "c:\\Users\\k.zavadsky\\Dropbox\\University\\ЦОСиИ\\Images\\liters\\";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // pictureBox_Class1
            // 
            this.pictureBox_Class1.Location = new System.Drawing.Point(285, 27);
            this.pictureBox_Class1.Name = "pictureBox_Class1";
            this.pictureBox_Class1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox_Class1.TabIndex = 5;
            this.pictureBox_Class1.TabStop = false;
            // 
            // textBox_Class1
            // 
            this.textBox_Class1.Location = new System.Drawing.Point(285, 93);
            this.textBox_Class1.Name = "textBox_Class1";
            this.textBox_Class1.Size = new System.Drawing.Size(60, 20);
            this.textBox_Class1.TabIndex = 8;
            // 
            // textBox_Class2
            // 
            this.textBox_Class2.Location = new System.Drawing.Point(285, 197);
            this.textBox_Class2.Name = "textBox_Class2";
            this.textBox_Class2.Size = new System.Drawing.Size(60, 20);
            this.textBox_Class2.TabIndex = 10;
            // 
            // pictureBox_Class2
            // 
            this.pictureBox_Class2.Location = new System.Drawing.Point(285, 131);
            this.pictureBox_Class2.Name = "pictureBox_Class2";
            this.pictureBox_Class2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox_Class2.TabIndex = 9;
            this.pictureBox_Class2.TabStop = false;
            // 
            // textBox_Class3
            // 
            this.textBox_Class3.Location = new System.Drawing.Point(285, 303);
            this.textBox_Class3.Name = "textBox_Class3";
            this.textBox_Class3.Size = new System.Drawing.Size(60, 20);
            this.textBox_Class3.TabIndex = 12;
            // 
            // pictureBox_Class3
            // 
            this.pictureBox_Class3.Location = new System.Drawing.Point(285, 237);
            this.pictureBox_Class3.Name = "pictureBox_Class3";
            this.pictureBox_Class3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox_Class3.TabIndex = 11;
            this.pictureBox_Class3.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 329);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(270, 23);
            this.progressBar.TabIndex = 13;
            // 
            // label_Cycles
            // 
            this.label_Cycles.AutoSize = true;
            this.label_Cycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Cycles.Location = new System.Drawing.Point(285, 329);
            this.label_Cycles.Name = "label_Cycles";
            this.label_Cycles.Size = new System.Drawing.Size(0, 17);
            this.label_Cycles.TabIndex = 14;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 359);
            this.Controls.Add(this.label_Cycles);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBox_Class3);
            this.Controls.Add(this.pictureBox_Class3);
            this.Controls.Add(this.textBox_Class2);
            this.Controls.Add(this.pictureBox_Class2);
            this.Controls.Add(this.textBox_Class1);
            this.Controls.Add(this.pictureBox_Class1);
            this.Controls.Add(this.label_Noise);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBox_Noise);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.trackBar_Noise);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "Lab4 - Multilayer Perceptron";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Noise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Class3)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox_Class1;
        private System.Windows.Forms.TextBox textBox_Class1;
        private System.Windows.Forms.TextBox textBox_Class2;
        private System.Windows.Forms.PictureBox pictureBox_Class2;
        private System.Windows.Forms.TextBox textBox_Class3;
        private System.Windows.Forms.PictureBox pictureBox_Class3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_Cycles;
    }
}

