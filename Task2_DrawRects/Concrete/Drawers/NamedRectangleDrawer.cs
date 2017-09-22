using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Concrete
{
    public class NamedRectangleDrawer : DrawerDecorator
    {
        private string name;
        public NamedRectangleDrawer(EmguCVDrawer drawer, string name)
            : base(drawer.Frame, drawer.Point, drawer)
        {
            this.name = name;
        }

        public override void Draw()
        {
            drawer.Draw();

            Font font = new Font("Arial", 18, FontStyle.Bold);
            Graphics g = Graphics.FromImage(Frame.Bitmap);
            g.DrawString(name, font, Brushes.White, (float)Point.X, (float)Point.Y - 30);
        }
    }
}
