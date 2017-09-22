using EmvuCV_VideoPlayer.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Concrete
{
    public class CoordinatedRectangleDrawer : DrawerDecorator
    {
        public CoordinatedRectangleDrawer(EmguCVDrawer drawer)
            : base(drawer.Frame, drawer.Point, drawer)
        {}

        public override void Draw()
        {
            drawer.Draw();
            Font font = new Font("Arial", 15, FontStyle.Bold);
            Graphics g = Graphics.FromImage(Frame.Bitmap);
            string result = string.Format("({0}, {1})", (int)Point.X, (int)Point.Y);

            g.DrawString(result, font, Brushes.White, (float)Point.X, (float)Point.Y + 105);
        }
    }
}
