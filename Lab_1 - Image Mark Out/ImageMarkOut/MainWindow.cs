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
        Dictionary<int, int> gistogram;
        Bitmap baseImage;
        int width;
        int height;
        
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
            if (baseImage != null)
            {
                baseImage.Dispose();
            }
            fileName = (sender as OpenFileDialog).FileName;

            baseImage = Bitmap.FromFile(fileName) as Bitmap;
            pictureBox_Base.Image = baseImage as Image;
            width = baseImage.Width;
            height = baseImage.Height;

            gistogram = ImageProcessing.GetGistogram(baseImage);
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
            var bwArray = ImageProcessing.GetBlackWhitePixelArray(baseImage as Bitmap, 10);
            Invoke(reloadImage, ImageProcessing.GetImage(bwArray, width, height));

            var markOutArray = MarkOut(bwArray);
            var markOutImage = ImageProcessing.GetImage(markOutArray, width, height);
            //Invoke(reloadImage, markOutImage.Clone());
            markOutImage.Save("out.jpg", ImageFormat.Jpeg);
        }

        private int[] MarkOut(int[] binArray)
        {
            int[,] markOutArray = new int[width, height];
            int[,] doubleBinArray = ImageProcessing.SingleArrayToDouble(binArray, width);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (doubleBinArray[x, y] == -1 && markOutArray[x, y] == 0)
                    {
                        RecursiveMarkOut(doubleBinArray, ref markOutArray, y * width + x, x, y, 0);
                        //RecursiveMarkOut(doubleBinArray, ref markOutArray, 1000, 0, 0, 0);
                    }
                }
            }
            return ImageProcessing.DoubleArrayToSingle(markOutArray, width);
        }

        private void RecursiveMarkOut(int[,] binArray, ref int[,] markOutArray, int color, int x, int y, int deep)
        {
            if (deep > 100) return;

            if (binArray[x, y] == -1 && markOutArray[x, y] == 0)
            {
                markOutArray[x, y] = color;

                if (x + 1 < width)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x + 1, y, deep + 1);
                if (x + 1 < width && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x + 1, y + 1, deep + 1);
                if (y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x, y + 1, deep + 1);
                if (x > 0 && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x - 1, y + 1, deep + 1);
                if (x > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x - 1, y, deep + 1);
                if (x > 0 && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x - 1, y - 1, deep + 1);
                if (y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x, y - 1, deep + 1);
                if (x + 1 < width && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, color, x + 1, y - 1, deep + 1);
            }
        }

        private void ReloadImage(Bitmap image)
        {
            pictureBox_Result.Image = image as Image;
        }
        #endregion
    }
}
