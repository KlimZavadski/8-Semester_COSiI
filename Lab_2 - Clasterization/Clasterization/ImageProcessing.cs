using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Clasterization
{
    public struct Claster
    {
        public int Id;
        public int Square;
        public int Perimeter;
        public double Compact;
        //public PointF Center;
        //public double Elongation;
    }


    public class ImageProcessor
    {
        public int[,] Image { get; set; }

        public int[] PixelArray { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Dictionary<int, int> Gistogram { get; set; }

        public int[,] MarkOutArray { get; set; }

        public List<Claster> ClassterList { get; set; }


        public ImageProcessor(Bitmap image)
        {
            Width = image.Width;
            Height = image.Height;
            Image = ToArray(image);
            PixelArray = ToSingleArray(Image, Width);
            var greyArray = ToGreyArray(Image, Width, Height);
            Gistogram = GetGistogram(greyArray, Width, Height);
        }

        public void GetGistogram()
        {
            Gistogram = GetGistogram(Image, Width, Height);
        }

        public static Dictionary<int, int> GetGistogram(int[,] greyArray, int width, int height)
        {
            Dictionary<int, int> gistogram = new Dictionary<int, int>(256);
            for (int key = 0; key < 256; key++)
            {
                gistogram.Add(key, 0);
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    gistogram[greyArray[y, x]]++;
                }
            }

            return gistogram;
        }

        #region Arrays

        public static int[,] ToArray(Bitmap image)
        {
            Size size = image.Size;
            var pixelArray = new int[size.Height, size.Width];

            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    pixelArray[y, x] = image.GetPixel(x, y).ToArgb();
                }
            }
            
            return pixelArray;
        }

        public void ToGreyArray()
        {
            Image = ToGreyArray(Image, Width, Height);
        }

        public static int[,] ToGreyArray(int[,] array, int width, int height)
        {
            var greyArray = new int[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    greyArray[y, x] = (int)(0.3*(byte) (array[y, x] >> 16) + 0.59*(byte) (array[y, x] >> 8) + 0.11*(byte) array[y, x]);
                }
            }
            
            return greyArray;
        }
        #endregion

        #region BlackWhite

        public int[,] ToBlackWhitePixelArray(int[,] image, int addCoeff)
        {
            if (image == null)
            {
                Image = ToBlackWhitePixelArray(ToGreyArray(Image, Width, Height), Width, Height, addCoeff);
                return Image;
            }
            return ToBlackWhitePixelArray(ToGreyArray(image, Width, Height), Width, Height, addCoeff);
        }

        public static int[,] ToBlackWhitePixelArray(int[,] greyArray, int width, int height, int threshold, int k)
        {
            int black = Color.Black.ToArgb();
            int white = Color.White.ToArgb();
            var bwArray = new int[height, width];
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bwArray[y, x] = (greyArray[y, x] < threshold + k) ? black : white;
                }
            }
            
            return bwArray;
        }

        public static int[,] ToBlackWhitePixelArray(int[,] array, int width, int height, int k)
        {
            var greyArray = ToGreyArray(array, width, height);
            var gistogram = GetGistogram(greyArray, width, height);

            int threshold = 0;
            for (int key = 0; key < 256; key++)
            {
                threshold += gistogram[key] * key;
            }
            threshold /= greyArray.Length;

            return ToBlackWhitePixelArray(greyArray, width, height, threshold, k);
        }
        #endregion

        #region SingleDouble

        public static int[,] ToDoubleArray(int[] singleArray, int width)
        {
            if (singleArray.Length % width == 0)
            {
                var height = singleArray.Length / width;
                var doubleArray = new int[height, width];

                for (int index = 0; index < singleArray.Length; index++)
                {
                    doubleArray[index / width, index % width] = singleArray[index];
                }
                return doubleArray;
            }
            return null;
        }

        public static int[] ToSingleArray(int[,] doubleArray, int width)
        {
            if (doubleArray.Length % width == 0)
            {
                int[] singleArray = new int[doubleArray.Length];

                for (int index = 0; index < doubleArray.Length; index++)
                {
                    singleArray[index] = (int) doubleArray[index / width, index % width];
                }
                return singleArray;
            }
            return null;
        }
        #endregion

        #region Images

        public Bitmap ToImage()
        {
            return ToImage(Image, Width, Height);
        }

        public static Bitmap ToImage(int[,] pixelArray, int width, int height)
        {
            if (pixelArray.Length % width == 0)
            {
                Bitmap binImage = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        binImage.SetPixel(x, y, Color.FromArgb(pixelArray[y, x]));
                    }
                }
                return binImage;
            }
            return null;
        }

        #endregion

        #region Filters

        public int[,] MedianFiter(int[,] image, int sizeOfWindow)
        {
            if (image == null)
            {
                Image = MedianFiter(Image, sizeOfWindow, Width, Height);
                return Image;
            }
            return MedianFiter(image, sizeOfWindow, Width, Height);
        }

        public static int[,] MedianFiter(int[,] pixelArray, int sizeOfWindow, int width, int height)
        {
            var half = sizeOfWindow / 2;
            var median = new int[sizeOfWindow];
            var medianPixelArray = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int i = 0; i < sizeOfWindow; i++)
                    {
                        if (x < sizeOfWindow)
                        {
                            median[i] = (x - half + i < 0)
                                            ? pixelArray[y, 0]
                                            : pixelArray[y, x - half + i];
                        }
                        else
                        {
                            median[i] = (x - half + i >= width)
                                            ? pixelArray[y, width - 1]
                                            : pixelArray[y, x - half + i];
                        }
                    }
                    var list = median.ToList();
                    list.Sort();
                    medianPixelArray[y, x] = list[half];
                }
            }
            return medianPixelArray;
        }
        #endregion

        #region MarkOut

        public int[,] MarkOut(int[,] image)
        {
            if (image == null)
            {
                Image = MarkOut(Image, Width, Height);
                return Image;
            }
            return MarkOut(image, Width, Height);
        }

        public static int[,] MarkOut(int[,] binArray, int width, int height)
        {
            var markOutArray = new int[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (binArray[y, x] != -16777216 && markOutArray[y, x] == 0)  // When object was found and didn't paint.
                    {
                        RecursiveMarkOut(binArray, ref markOutArray, width, height, y * width + x + 100, y, x, 0);
                    }
                }
            }
            return markOutArray;
        }

        public static void RecursiveMarkOut(int[,] binArray, ref int[,] markOutArray, int width, int height, int color, int y, int x, int deep)
        {
            if (++deep > 20000) return;

            if (binArray[y, x] != -16777216 && markOutArray[y, x] == 0)
            {
                markOutArray[y, x] = color;

                if (x + 1 < width)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y, x + 1, deep);
                if (x + 1 < width && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y + 1, x + 1, deep);
                if (y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y + 1, x, deep);
                if (x > 0 && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y + 1, x - 1, deep);
                if (x > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y, x - 1, deep);
                if (x > 0 && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y - 1, x - 1, deep);
                if (y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y - 1, x, deep);
                if (x + 1 < width && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, y - 1, x + 1, deep);
            }
        }

        #endregion

        #region Classterize

        public List<Claster> Clasterize(int[,] image)
        {
            if (image == null)
            {
                ClassterList = Clasterize(Image, Width, Height);
                return ClassterList;
            }
            return Clasterize(image, Width, Height);
        }

        public static List<Claster> Clasterize(int[,] image, int width, int height)
        {
            var classterList = new List<Claster>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int color = image[y, x];
                    if (color != 0)   // If this color don't exist, then create it.
                    {
                        if (classterList.Where(item => item.Id == color).Count() == 0)
                        {
                            classterList.Add(GetClaster(image, y, x, width, height));
                        }
                    }
                }
            }
            return classterList;
        }

        private static Claster GetClaster(int[,] image, int y0, int x0, int width, int height)
        {
            var claster = new Claster();
            claster.Id = image[y0, x0];
            for (int y = y0; y < height; y++)
            {
                for (int x = x0; x < width; x++)
                {
                    if (image[y, x] == claster.Id)
                    {
                        claster.Square++;
                        if (IsBorder(image, y, x)) claster.Perimeter++;
                    }
                }
            }
            claster.Compact = Math.Pow((double)claster.Perimeter, 2.0) / claster.Square;
            return claster;
        }

        private static bool IsBorder(int[,] image, int y, int x)
        {
            int color = image[y, x];
            return image[y - 1, x] != color
                || image[y - 1, x + 1] != color
                || image[y, x + 1] != color
                || image[y + 1, x + 1] != color
                || image[y + 1, x] != color
                || image[y + 1, x - 1] != color
                || image[y, x - 1] != color
                || image[y - 1, x - 1] != color;
        }
        #endregion
    }
}
