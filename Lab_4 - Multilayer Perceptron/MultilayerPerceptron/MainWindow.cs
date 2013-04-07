using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultilayerPerceptron
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events

        private void trainingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trackBar_Noise_MouseUp(object sender, MouseEventArgs e)
        {
            // Set Noise. ((sender as TrackBar).Value);
        }

        private void trackBar_Noise_ValueChanged(object sender, EventArgs e)
        {
            textBox_Noise.Text = (sender as TrackBar).Value.ToString();
        }
        #endregion
    }
}
