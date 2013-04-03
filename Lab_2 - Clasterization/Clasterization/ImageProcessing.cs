using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Clasterization
{
    public class Shape : IComparable<Shape>
    {
        public int Id;
        public Point Coord;
        public PointF Center;
        public double Distance;

        public double Compact;
        public int Perimeter;
        public int Square;
        public double Elongation;
        public double Direction;
        
        public double GetDistance(Shape center)
        {
            return Math.Sqrt(Math.Pow(center.Compact - this.Compact, 2.0) +
                             Math.Pow(center.Perimeter - this.Perimeter, 2.0) +
                             Math.Pow(center.Square - this.Square, 2.0) +
                             Math.Pow(center.Elongation - this.Elongation, 2.0));
        }

        public int CompareTo(Shape other)
        {
            if (this.Distance < other.Distance) return 1;
            else if (this.Distance > other.Distance) return -1;
            else return 0;
        }

        public Shape Clone()
        {
            return new Shape()
                {
                    Id = Id,
                    Coord = Coord,
                    Center = Center,
                    Distance = Distance,
                    Compact = Compact,
                    Perimeter = Perimeter,
                    Square = Square,
                    Elongation = Elongation,
                    Direction = Direction
                };
        }

        public override string ToString()
        {
            return "Id: " + Id.ToString() + Environment.NewLine +
                "\n  Center: " + Center.ToString() + Environment.NewLine +
                "\n  Square: " + Square.ToString() + Environment.NewLine +
                "\n  Perimeter: " + Perimeter.ToString() + Environment.NewLine +
                "\n  Compact: " + Compact.ToString() + Environment.NewLine +
                "\n  Elongation: " + Elongation.ToString() + Environment.NewLine +
                "\n  Direction: " + Direction.ToString() + Environment.NewLine;
        }

        public override bool Equals(object obj)
        {
            return obj != null && (obj as Shape).Id == Id;
        }
    }

    public class Claster
    {
        public Shape Center { get; set; }
        public List<Shape> Shapes { get; set; }
        
        //public void Add(Shape shape)
        //{
        //    Shapes.Add(shape);
        //}

        //public void Remove(Shape shape)
        //{
        //    Shapes.Remove(shape);
        //}

        public Shape GetCenter()
        {
            var center = new Shape();
            foreach (var shape in Shapes)
            {
                center.Center.X += shape.Center.X;
                center.Center.Y += shape.Center.Y;
                center.Perimeter += shape.Perimeter;
                center.Square += shape.Square;
                center.Elongation += shape.Elongation;
                center.Direction += shape.Direction;
            }
            center.Center.X /= Shapes.Count;
            center.Center.Y /= Shapes.Count;
            center.Perimeter /= Shapes.Count;
            center.Square /= Shapes.Count;
            center.Elongation /= Shapes.Count;
            center.Direction /= Shapes.Count;
            center.Compact = Math.Pow(center.Perimeter, 2.0) / center.Square;

            return center;
        }

        public void Sort()
        {
            foreach (var shape in Shapes)
            {
                shape.Distance = shape.GetDistance(Center);
            }
            Shapes.Sort();
        }

        public Claster Clone()
        {
            var shapes = new List<Shape>(Shapes.Count);
            foreach (var shape in Shapes)
            {
                shapes.Add(shape.Clone());
            }
            return new Claster()
                {
                    Center = Center,
                    Shapes = shapes
                };
        }

        public override string ToString()
        {
            return Shapes.Count + "  Center: " + Center.ToString();
        }
    }


    public class ImageProcessor
    {
        public int[,] Image { get; set; }

        public int[] PixelArray { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Dictionary<int, int> Gistogram { get; set; }

        public List<Shape> ShapeList { get; set; }

        public List<Claster> ClasterList { get; set; }


        private static readonly int[] colors = new int[]
            {
                0xc0c0ff, 0xc0ffff, 0xffffc0, 0x808000, 0xffc0c0, 0xffc0ff, 0xe0e0e0,
                0x8080ff, 0x80c0ff, 0x80ffff, 0x80ff80, 0xffff80, 0xff8080, 0xff80ff, 0xc0c0c0, 0xff, 0x80ff,
                0xffff, 0xff00, 0xffff00, 0xff0000, 0xff00ff, 0x808080, 0xc0, 0x40c0, 0xc0c0, 0xc000, 0xc0c000,
                0xc00000, 0xc000c0, 0x404040, 0x80, 0x4080, 0x8080, 0xc0ffc0, 0x8000, 0x800000, 0x800080, 0,
                0x40, 0x404080, 0x4040, 0x4000, 0x404000, 0x400000, 0x400040
            };
        private static readonly int white = Color.White.ToArgb();
        private static readonly int black = Color.Black.ToArgb();


        public ImageProcessor(Bitmap image)
        {
            Width = image.Width;
            Height = image.Height;
            Image = ToArray(image);
            PixelArray = ToSingleArray(Image, Width);
            var greyArray = ToGreyArray(Image, Width, Height);
            Gistogram = GetGistogram(greyArray, Width, Height);

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = ColorTranslator.FromOle(colors[i]).ToArgb();
            }
        }

        #region Gistograms

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
        #endregion

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
            var markOutArray = GetEmptyArray(width, height);
            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (binArray[y, x] == white && markOutArray[y, x] == black)
                    {
                        RecursiveMarkOut(binArray, ref markOutArray, width, height, white, colors[index], y, x, 0);
                        index++;
                    }
                }
            }
            return markOutArray;
        }

        private static int[,] GetEmptyArray(int width, int height)
        {
            var markOutArray = new int[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    markOutArray[y, x] = black;
                }
            }
            return markOutArray;
        }

        public static void RecursiveMarkOut(int[,] binArray, ref int[,] markOutArray, int width, int height, int color, int brushColor, int y, int x, int deep)
        {
            if (++deep > 10000) return;

            if (binArray[y, x] == color && markOutArray[y, x] == black)
            {
                markOutArray[y, x] = brushColor;

                if (x + 1 < width)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y, x + 1, deep);
                if (x + 1 < width && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y + 1, x + 1, deep);
                if (y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y + 1, x, deep);
                if (x > 0 && y + 1 < height)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y + 1, x - 1, deep);
                if (x > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y, x - 1, deep);
                if (x > 0 && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y - 1, x - 1, deep);
                if (y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y - 1, x, deep);
                if (x + 1 < width && y > 0)
                    RecursiveMarkOut(binArray, ref markOutArray, width, height, color, brushColor, y - 1, x + 1, deep);
            }
        }

        #endregion

        #region Classterize

        public int[,] Clasterize(int[,] image, int clasterCount)
        {
            if (image == null)
            {
                image = Image;
            }
            ShapeList = GetShapes(image, Width, Height);
            if (ShapeList.Count > 1)
            {
                ClasterList = GetClasters(ShapeList, clasterCount, Width, Height);
                Image = MarkOutClasters(image, ClasterList, Width, Height);
            }
            return Image;
            //return Clasterize(image, clasterCount, Width, Height);
        }

        public static int[,] Clasterize(int[,] image, int clasterCount, int width, int height)
        {
            var markOutArray = new int[width, height];
            var shapeList = GetShapes(image, width, height);
            if (shapeList.Count > 1)
            {
                var clasterList = GetClasters(shapeList, clasterCount, width, height);
                markOutArray = MarkOutClasters(image, clasterList, width, height);
            }
            return markOutArray;
        }

        public static List<Shape> GetShapes(int[,] image, int width, int height)
        {
            var shapeList = new List<Shape>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int color = image[y, x];
                    if (color != black)   // If this color don't exist, then create it.
                    {
                        if (shapeList.All(item => item.Id != color))
                        {
                            shapeList.Add(GetShapeParams(image, y, x, width, height));
                        }
                    }
                }
            }
            return shapeList;
        }

        private static Shape GetShapeParams(int[,] image, int y0, int x0, int width, int height)
        {
            var shape = new Shape();
            shape.Id = image[y0, x0];
            shape.Coord = new Point(x0, y0);

            // Get simple properties.
            double mX = 0;
            double mY = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (image[y, x] == shape.Id)
                    {
                        shape.Square++;
                        mX += x;
                        mY += y;
                        if (IsBorder(image, y, x, width, height)) shape.Perimeter++;
                    }
                }
            }
            shape.Compact = Math.Pow(shape.Perimeter, 2.0) / shape.Square;
            shape.Center = new PointF((float)(mX / shape.Square), (float)(mY / shape.Square));

            // Get Elongation and Direction.
            double m02 = 0;
            double m20 = 0;
            double m11 = 0;
            mX = shape.Center.X;
            mY = shape.Center.Y;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (image[y, x] == shape.Id)
                    {
                        m02 += Math.Pow(y - mY, 2.0);
                        m20 += Math.Pow(x - mX, 2.0);
                        m11 += (y - mY) * (x - mX);
                    }
                }
            }
            double sqrt = Math.Sqrt(Math.Pow(m20 - m02, 2.0) + 4 * m11);
            shape.Elongation = (m20 + m02 + sqrt) / (m20 + m02 - sqrt);
            shape.Direction = 0.5 * Math.Atan(2 * m11 / (m20 - m02));
            return shape;
        }

        private static bool IsBorder(int[,] image, int y, int x, int width, int height)
        {
            int color = image[y, x];
            return (y > 0 && image[y - 1, x] != color) ||
                (y > 0 && x + 1 < width && image[y - 1, x + 1] != color) ||
                (x + 1 < width && image[y, x + 1] != color) ||
                (y + 1 < height && x + 1 < width && image[y + 1, x + 1] != color) ||
                (y + 1 < height && image[y + 1, x] != color) ||
                (y + 1 < height && x > 0 && image[y + 1, x - 1] != color) ||
                (x > 0 && image[y, x - 1] != color) ||
                (x > 0 && y > 0 && image[y - 1, x - 1] != color);
        }


        public static List<Claster> GetClasters(List<Shape> shapeList, int clasterCount, int width, int height)
        {
            var clasterList = InitializeClasters(shapeList, clasterCount > shapeList.Count ? shapeList.Count : clasterCount);
            ClasterAllocation(ref clasterList, shapeList);

            List<Claster> oldClasterList;
            do
            {
                oldClasterList = new List<Claster>(clasterList.Count);
                foreach (var claster in clasterList)
                {
                    oldClasterList.Add(claster.Clone());  // Copy claster list.
                    claster.Center = claster.GetCenter();  // Recount center of claster and find new one claster.
                }
                ClasterAllocation(ref clasterList, shapeList);
            } while (!AreEqual(clasterList, oldClasterList));

            return clasterList;
        }

        private static List<Claster> InitializeClasters(List<Shape> shapeList, int clasterCount)
        {
            var clasterList = new List<Claster>(clasterCount);
            for (int i = 0; i < clasterCount; i++)
            {
                clasterList.Add(new Claster()
                {
                    Center = shapeList[i]
                });
            }
            return clasterList;
        }

        private static void ClasterAllocation(ref List<Claster> clasterList, List<Shape> shapeList)
        {
            foreach (var claster in clasterList)
            {
                claster.Shapes = new List<Shape>();
            }
            foreach (var shape in shapeList)
            {
                int index = 0;
                double min = shape.GetDistance(clasterList[0].Center);
                if (min != 0.0)
                {
                    for (int i = 1; i < clasterList.Count; i++)
                    {
                        double distance = shape.GetDistance(clasterList[i].Center);
                        if (distance < min)
                        {
                            min = distance;
                            index = i;
                        }
                    }
                }
                clasterList[index].Shapes.Add(shape);
            }
        }

        private static bool AreEqual(List<Claster> list1, List<Claster> list2)
        {
            if (list1 == null || list2 == null) return false;
            if (list1.Count() != list2.Count()) return false;
            for (int i = 0; i < list1.Count(); i++)
            {
                if (list1[i].Shapes.Count != list2[i].Shapes.Count) return false;
                for (int j = 0; j < list1[i].Shapes.Count; j++)
                {
                    if (!list1[i].Shapes[j].Equals(list2[i].Shapes[j])) return false;
                }
            }
            return true;
        }


        public static int[,] MarkOutClasters(int[,] image, List<Claster> clasterList, int width, int height)
        {
            var markOutArray = GetEmptyArray(width, height);
            int index = 0;
            foreach (var claster in clasterList)
            {
                foreach (var shape in claster.Shapes)
                {
                    RecursiveMarkOut(image, ref markOutArray, width, height, shape.Id, colors[index], shape.Coord.Y, shape.Coord.X, 0);
                }
                claster.Center.Id = colors[index];
                index++;
            }
            return markOutArray;
        }

        #endregion
    }
}
