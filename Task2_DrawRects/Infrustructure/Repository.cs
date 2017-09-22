using EmvuCV_VideoPlayer.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EmvuCV_VideoPlayer.Infrustructure
{
    public class Repository
    {
        public string GetNameFromCommandArg(string arg)
        {
            Dictionary<string, string> argsDictionary = new Dictionary<string, string>();
            string videoName = string.Empty;

            string[] args = Environment.GetCommandLineArgs();

            for (int index = 1; index < args.Length; index += 2)
            {
                if (index + 1 < args.Length)
                {
                    argsDictionary.Add(args[index], args[index + 1]);
                }
            }

            argsDictionary.TryGetValue(arg, out videoName);
            return videoName;
        }

        public BitmapSource ConvertBitmapToBitmapSource(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height, 96, 96, PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        public TimePoint LagrangeInterpolatePoint(double time, ObservableCollection<TimePoint> points)
        {
            TimePoint resultPoint = null;

            if (points.Count > 0)
            {
                double[] timeValues = points.Select(p => p.Time).ToArray();

                double[] xValues = points.Select(p => p.X).ToArray();
                double[] yValues = points.Select(p => p.Y).ToArray();
                double x = 0, y = 0;
                int i, j;

                for (i = 0; i < points.Count; i++)
                {
                    double basicsPol = 1;
                    for (j = 0; j < points.Count; j++)
                    {
                        if (j != i)
                        {
                            basicsPol *= (time - timeValues[j]) / (timeValues[i] - timeValues[j]);
                        }
                    }
                    x += basicsPol * xValues[i];
                    y += basicsPol * yValues[i];
                }

                resultPoint = new TimePoint(time, x, y);
            }
            return resultPoint;
        }
    }
}
