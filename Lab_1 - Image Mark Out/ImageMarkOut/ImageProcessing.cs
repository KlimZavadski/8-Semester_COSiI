using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageMarkOut
{
    internal static class ImageProcessor
    {
        public static Dictionary<int, int> GetGistogram(int[] greyArray)
        {
            Dictionary<int, int> gistogram = new Dictionary<int, int>(256);
            for (int key = 0; key < 256; key++)
            {
                gistogram.Add(key, 0);
            }
            ToGreyPixelArray(greyArray).Aggregate(0, (index, pixel) =>
                                                  gistogram[pixel]++);
            return gistogram;
        }

        #region Converters

        public static int[] ToPixelArray(Bitmap image)
        {
            Size size = image.Size;
            int[] array = new int[size.Height * size.Width];

            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    array[y * size.Width + x] = image.GetPixel(x, y).ToArgb();
                }
            }
            return array;
        }

        public static int[] ToGreyPixelArray(int[] pixelArray)
        {
            return pixelArray.Select(pixel => new
                                {
                                    greyPixel = (int)(0.3 * (byte)(pixel >> 16) + 0.59 * (byte)(pixel >> 8) + 0.11 * (byte)pixel)
                                })
                            .Select(item => item.greyPixel)
                            .ToArray();
        }

        public static int[] ToBlackWhitePixelArray(int[] greyArray, int threshold, int k)
        {
            int black = Color.Black.ToArgb();
            int white = Color.White.ToArgb();

            return greyArray.Select(greyPixel => new
                              {
                                  bwPixel = (greyPixel < threshold + k)
                                                ? black
                                                : white
                              })
                              .Select(item => item.bwPixel)
                              .ToArray();
        }

        public static int[] ToBlackWhitePixelArray(int[] greyArray, int k)
        {
            var gistogram = GetGistogram(greyArray);
            
            int threshold = 0;
            for (int key = 0; key < 256; key++)
            {
                threshold += gistogram[key] * key;
            }
            threshold /= greyArray.Length;

            return ToBlackWhitePixelArray(greyArray, threshold, k);
        }

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

        public static Bitmap ToImage(int[] pixelArray, int width, int height)
        {
            if (pixelArray.Length % width == 0)
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
            return null;
        }
        #endregion

        #region Filters

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
    }
}
