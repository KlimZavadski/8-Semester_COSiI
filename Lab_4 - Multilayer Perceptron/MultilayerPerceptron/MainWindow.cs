using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace MultilayerPerceptron
{
    public partial class MainWindow : Form
    {
        #region Constants

        private double aK = 0.7;
        private double bK = 0.7;
        private double limitD = 0.01;

        #endregion

        #region Fields

        private String[] fileNames;
        private int cycles = 0;
        private Bitmap openedImage;

        private Thread worker;
        private delegate void UpdateProgressDelegate(int percent);
        private readonly UpdateProgressDelegate updateProgressDelegate;

        private int n = 256;
        private int h = 256;
        private int m = 3;

        private double[] v;
        private double[] w;
        private double[] Q;
        private double[] T;

        #endregion




        public MainWindow()
        {
            InitializeComponent();

            updateProgressDelegate = new UpdateProgressDelegate(UpdateProgress);

            v = new double[n * h];
            w = new double[h * m];
            Q = new double[h];
            T = new double[m];
        }

        #region Events

        private void trainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.Abort();
            }
            worker = new Thread(new ThreadStart(Recognize))
                {
                    Priority = ThreadPriority.Highest
                };

            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileNames = (sender as OpenFileDialog).FileNames;
            //if (fileNames.Count() != 9) return;

            var list = new List<String[]>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(fileNames.Skip(i * 3).Take(3).ToArray());
            }

            worker.Start(list);
        }


        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog_OpenImage.ShowDialog();
        }

        private void openFileDialog_OpenImage_FileOk(object sender, CancelEventArgs e)
        {
            var fileName = (sender as OpenFileDialog).FileName;
            openedImage = Bitmap.FromFile(fileName) as Bitmap;
            pictureBox.Image = openedImage;
        }

        private void recognizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.Abort();
            }
            worker = new Thread(new ParameterizedThreadStart(TrainingNetwork))
                {
                    Priority = ThreadPriority.Highest
                };
        }


        private void trackBar_Noise_MouseUp(object sender, MouseEventArgs e)
        {
            // Set Noise. ((sender as TrackBar).Value);
        }

        private void trackBar_Noise_ValueChanged(object sender, EventArgs e)
        {
            textBox_Noise.Text = (sender as TrackBar).Value.ToString();
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker != null)
            {
                worker.Abort();
            }
        }
        #endregion

        #region private methods

        #region Learning

        private void TrainingNetwork(object param)
        {
            int cycle = 0;
            var namesList = param as List<String[]>;
            if (namesList == null) return;

            var imageList = GetImageList(namesList);
            InitializeVariables(ref v);
            InitializeVariables(ref w);
            InitializeVariables(ref Q);
            InitializeVariables(ref T);

            double Dmax;
            do
            {
                Dmax = 0;
                foreach (var list in imageList)
                {
                    foreach (var image in list.Images)
                    {
                        // Counting outputs.
                        var g = CountingLayer(image, v, Q, h);  // Use n -> h.
                        var y = CountingLayer(g, w, T, m);  // Use h -> m.

                        // Counting OUTPUT layer.
                        var d = GetOutputError(y, list.Clas);
                        Dmax = GetMaxError(d);
                        
                        ChangeWeight(ref w, aK, y, d, g, h, m);
                        ChangeThreshold(ref T, aK, y, d, m);

                        // Counting HIDE layer.
                        var e = GetHideError(g, d);
                        ChangeWeight(ref v, bK, g, e, image, n, h);
                        ChangeThreshold(ref Q, bK, g, e, h);
                    }
                }

                if (++cycle % 10 == 0)
                {
                    if (Dmax < 0.011) aK = bK = 0.5;

                    using (var writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine(String.Format("{0}\t{1}\t{2}", cycle, Dmax, aK));
                    }
                    Invoke(updateProgressDelegate, cycle);
                }
            } while (Dmax > limitD);

            Invoke(updateProgressDelegate, cycle);
        }

        private List<ImageList> GetImageList(List<String[]> namesList)
        {
            int clasCount = namesList.Count;
            var imageList = new List<ImageList>(clasCount);
            
            for (int i = 0; i < clasCount; i++)
            {
                var list = new ImageList()
                {
                    Clas = i,
                    Images = new List<double[]>(namesList[i].Count())
                };
                foreach (var name in namesList[i])
                {
                    list.Images.Add(GetImage(name));
                }
                imageList.Add(list);
            }

            return imageList;
        }

        private double[] GetImage(String fileName)
        {
            var image = Bitmap.FromFile(fileName) as Bitmap;
            Size size = image.Size;

            var array = new double[size.Width * size.Height];
            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    array[y * size.Width + x] = image.GetPixel(x, y).ToArgb() < -1000000 ? 1.0 : 0.0;
                }
            }

            return array;
        }

        private void InitializeVariables(ref double[] array)
        {
            var random = new Random(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100) / 1000.0;
            }
        }
        
        #region Counting Layer

        private double[] CountingLayer(double[] input, double[] weight, double[] threshold, int jj)
        {
            var output = new double[jj];
            int ii = input.Length;

            for (int j = 0; j < jj; j++)
            {
                double d = 0;
                for (int i = 0; i < ii; i++)
                {
                    d += weight[j * ii + i] * input[i];
                }
                output[j] = ActivateFunc(d + threshold[j]);
            }

            return output;
        }

        private double ActivateFunc(double d)
        {
            return 1.0 / (1.0 + Math.Exp(-d));
        }

        private double GetMaxError(double[] errors)
        {
            double Dmax = 0;

            if (Dmax < errors.Max())
            {
                Dmax = errors.Max();
            }
            if (Dmax < Math.Abs(errors.Min()))
            {
                Dmax = Math.Abs(errors.Min());
            }

            return Dmax;
        }

        private double[] GetOutputError(double[] layer, int clas)
        {
            var errors = new double[m];

            for (int k = 0; k < m; k++)
            {
                double y = (clas == k) ? 1.0 : 0.0;
                errors[k] = y - layer[k];
            }

            return errors;
        }

        private double[] GetHideError(double[] layer, double[] outputErrors)
        {
            var errors = new double[h];

            for (int j = 0; j < h; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    double yk = layer[k];
                    errors[j] += outputErrors[k] * yk * (1 - yk) * w[j * m + k];
                }
            }

            return errors;
        }

        private void ChangeWeight(ref double[] weight, double coef, double[] layer, double[] error, double[] prevLayer, int jj, int kk)
        {
            for (int j = 0; j < jj; j++)
            {
                for (int k = 0; k < kk; k++)
                {
                    double z = layer[k];
                    weight[j * kk + k] += coef * z * (1 - z) * error[k] * prevLayer[j];
                }
            }
        }

        private void ChangeThreshold(ref double[] threshold, double coef, double[] layer, double[] error, int kk)
        {
            for (int k = 0; k < kk; k++)
            {
                double z = layer[k];
                threshold[k] += coef * z * (1 - z) * error[k];
            }
        }

        #endregion

        #endregion

        private void Recognize()
        {
            //
        }

        private void SetNoise(int percent)
        {
            for (int i = 0; i < UPPER; i++)
            {
                
            }
        }


        private void UpdateProgress(int percent)
        {
            cycles = percent;
            label_Cycles.Text = cycles.ToString();
        }

        #endregion
    }
}
