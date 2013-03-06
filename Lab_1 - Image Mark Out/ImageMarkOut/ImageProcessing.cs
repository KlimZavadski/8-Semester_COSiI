using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageMarkOut
{
    static class ImageProcessing
    {
        static public int[] GetPixelArray(Bitmap image)
        {
            Size size = image.Size;
            int[] array = new int[size.Width * size.Height];

            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    array[i * size.Width + j] = image.GetPixel(j, i).ToArgb();
                }
            }
            return array;
        }

        static public Bitmap GetImage(int[] pixelArray, int width, int height)
        {
            Bitmap binImage = new Bitmap(width, height);
            for (int index = 0; index < pixelArray.Length; index++)
            {
                binImage.SetPixel(index % width,
                    index / width,
                    Color.FromArgb(pixelArray[index]));
            }
            return binImage;
        }

        static public int[] GetGreyPixelArray(Bitmap image)
        {
            return GetPixelArray(image)
                .Select(pixel => new
                {
                    greyPixel = (int)(0.3 * (byte)(pixel >> 16) + 0.59 * (byte)(pixel >> 8) + 0.11 * (byte)pixel)
                })
                .Select(item => item.greyPixel)
                .ToArray();
        }

        static public Dictionary<int, int> GetGistogram(Bitmap image)
        {
            Dictionary<int, int> gistogram = new Dictionary<int, int>(256);
            for (int key = 0; key < 256; key++)
            {
                gistogram.Add(key, 0);
            }
            GetGreyPixelArray(image).Aggregate(0, (index, pixel) =>
                gistogram[pixel]++);

            return gistogram;
        }

        static public int[] GetBlackWhitePixelArray(Bitmap image, int threshold, int k)
        {
            int black = Color.Black.ToArgb();
            int white = Color.White.ToArgb();

            return ImageProcessing.GetGreyPixelArray(image)
                .Select(greyPixel => new
                {
                    bwPixel = (greyPixel > threshold + k)
                        ? black
                        : white
                })
                .Select(item => item.bwPixel)
                .ToArray();
        }

        static public int[] GetBlackWhitePixelArray(Bitmap image, int k)
        {
            var gistogram = GetGistogram(image);
            int threshold = 0;

            for (int key = 0; key < 256; key++)
            {
                threshold += gistogram[key] * key;
            }
            threshold /= image.Width * image.Height;

            return GetBlackWhitePixelArray(image, threshold, k);
        }

        #region Converters

        static public int[,] SingleArrayToDouble(int[] singleArray, int width)
        {
            if (singleArray.Length % width == 0)
            {
                int height = singleArray.Length / width;
                int[,] doubleArray = new int[width, height];

                for (int index = 0; index < singleArray.Length; index++)
                {
                    doubleArray[index % width, index / width] = singleArray[index];
                }
                return doubleArray;
            }
            return null;
        }

        static public int[] DoubleArrayToSingle(int[,] doubleArray, int width)
        {
            if (doubleArray.Length % width == 0)
            {
                int[] singleArray = new int[doubleArray.Length];

                for (int index = 0; index < doubleArray.Length; index++)
                {
                    singleArray[index] = (int)doubleArray[index % width, index / width];
                }
                return singleArray;
            }
            return null;
        }
        #endregion
    }
}
