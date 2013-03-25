using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Clasterization
{
    public partial class MainWindow : Form
    {
        private String fileName;
        private Thread workerThread;
        private ImageProcessor imageProcessor;
        private int[,] baseImage;
        private delegate void ReloadImageDelegate(Bitmap image);
        private readonly ReloadImageDelegate reloadImage;


        public MainWindow()
        {
            InitializeComponent();

            EnabledAllButtons(false);
            reloadImage = new ReloadImageDelegate(ReloadImage);
        }
        
        #region Events

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox_Result.Image = null;
            fileName = (sender as OpenFileDialog).FileName;
            var image = Bitmap.FromFile(fileName) as Bitmap;
            pictureBox_Base.Image = image as Image;

            imageProcessor = new ImageProcessor(image);
            var gistogram = imageProcessor.Gistogram;
            baseImage = imageProcessor.Image;
            
            zedGraphControl.GraphPane.CurveList.Clear();
            zedGraphControl.GraphPane.AddCurve("",
                gistogram.Keys
                    .Select(x => new { value = (double)x })
                    .Select(x => x.value).ToArray(),
                gistogram.Values
                    .Select(x => new { value = (double)x })
                    .Select(x => x.value).ToArray(),
                Color.Black);
            zedGraphControl.GraphPane.Title.Text = "Gistogram";
            zedGraphControl.GraphPane.XAxis.Scale.Min = 0;
            zedGraphControl.GraphPane.XAxis.Scale.Max = 255;
            zedGraphControl.AxisChange();
            zedGraphControl.Refresh();

            processingToolStripMenuItem.Enabled = true;
        }

        private void EnabledAllButtons(bool isEnable)
        {
            return;
            processingToolStripMenuItem.Enabled = isEnable;
            classterizeToolStripMenuItem.Enabled = isEnable;
            saveToolStripMenuItem.Enabled = isEnable;
            trackBar_Coeff.Enabled = isEnable;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void binarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnabledAllButtons(false);
            workerThread = new Thread(new ParameterizedThreadStart(Worker), Int32.MaxValue / 4);
            workerThread.Start("Binarize");
        }

        private void classterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnabledAllButtons(false);
            workerThread = new Thread(new ParameterizedThreadStart(Worker), Int32.MaxValue / 4);
            workerThread.Start("Classterize");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnabledAllButtons(false);
            workerThread = new Thread(new ParameterizedThreadStart(Worker), Int32.MaxValue / 4);
            workerThread.Start("Save");
        }

        private void trackBar_Coeff_MouseUp(object sender, MouseEventArgs e)
        {
            binarizeToolStripMenuItem_Click(null, null);
        }
        #endregion

        #region Private mothods

        private void Worker(Object param)
        {
            switch (param as String)
            {
                case "Binarize":
                    imageProcessor.Image = imageProcessor.ToBlackWhitePixelArray(baseImage, 10);//trackBar_Coeff.Value);
                    Invoke(reloadImage, imageProcessor.ToImage());
                    imageProcessor.MedianFiter(null, 5);
                    Invoke(reloadImage, imageProcessor.ToImage());
                    imageProcessor.MarkOut(null);
                    break;
                case "Classterize":
                    Invoke(reloadImage, imageProcessor.ToImage());
                    imageProcessor.Clasterize(null);
                    break;
                case "Save":
                    imageProcessor.ToImage().Save("out.jpg", ImageFormat.Jpeg);
                    break;
            }
            EnabledAllButtons(true);
        }

        private void ReloadImage(Bitmap image)
        {
            pictureBox_Result.Image = image as Image;
        }
        #endregion
    }
}
