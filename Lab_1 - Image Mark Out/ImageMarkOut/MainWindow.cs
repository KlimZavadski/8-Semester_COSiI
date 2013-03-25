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

namespace ImageMarkOut
{
    public partial class MainWindow : Form
    {
        private String fileName;
        private Dictionary<int, int> gistogram;
        private int[] baseImage;
        private int width;
        private int height;
        
        private Thread workerThread;
        private delegate void ReloadImageDelegate(Bitmap image);
        private ReloadImageDelegate reloadImage;


        public MainWindow()
        {
            InitializeComponent();

            processingToolStripMenuItem.Enabled = false;
            reloadImage = new ReloadImageDelegate(ReloadImage);
        }
        
        #region Events

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox_Result.Image = null;
            baseImage = null;
            fileName = (sender as OpenFileDialog).FileName;

            var image = Bitmap.FromFile(fileName) as Bitmap;
            pictureBox_Base.Image = image as Image;
            width = image.Width;
            height = image.Height;

            baseImage = ImageProcessor.ToPixelArray(image);
            gistogram = ImageProcessor.GetGistogram(baseImage);
            
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void processingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processingToolStripMenuItem.Enabled = false;

            workerThread = new Thread(new ParameterizedThreadStart(Worker), Int32.MaxValue / 4);
            workerThread.Start(baseImage);
        }
        #endregion

        #region Private mothods

        private void Worker(Object baseImage)
        {
            var bwArray = ImageProcessor.ToBlackWhitePixelArray(baseImage as int[], 0);
            var bwArrayWithMedianFilter = ImageProcessor.MedianFiter(ImageProcessor.ToDoubleArray(bwArray, width), 5, width, height);
            Invoke(reloadImage, ImageProcessor.ToImage(bwArrayWithMedianFilter, width, height));

            var markOutArray = MarkOut(bwArrayWithMedianFilter);
            ImageProcessor.ToImage(markOutArray, width, height).Save("out.jpg", ImageFormat.Jpeg);
        }

        private int[,] MarkOut(int[,] binArray)
        {
            var markOutArray = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (binArray[y, x] != -1 && markOutArray[y, x] == 0)  // When object was found and didn't paint.
                    {
                        RecursiveMarkOut(binArray, ref markOutArray, y * width + x + 100, y, x, 0);
                    }
                }
            }
            return markOutArray;
        }

        private void RecursiveMarkOut(int[,] binArray, ref int[,] markOutArray, int color, int y, int x, int deep)
        {
            if (++deep > 20000) return;

            if (binArray[y, x] != -1 && markOutArray[y, x] == 0)
            {
                markOutArray[y, x] = color;

                if (x + 1 < width)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y, x + 1, deep);
                if (x + 1 < width && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y + 1, x + 1, deep);
                if (y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y + 1, x, deep);
                if (x > 0 && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y + 1, x - 1, deep);
                if (x > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y, x - 1, deep);
                if (x > 0 && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y - 1, x - 1, deep);
                if (y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y - 1, x, deep);
                if (x + 1 < width && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, y - 1, x + 1, deep);
            }
        }

        private void ReloadImage(Bitmap image)
        {
            pictureBox_Result.Image = image as Image;
        }
        #endregion
    }
}
