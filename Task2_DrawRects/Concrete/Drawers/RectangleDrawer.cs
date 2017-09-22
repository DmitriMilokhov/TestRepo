using EmvuCV_VideoPlayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace EmvuCV_VideoPlayer.Concrete
{
    class RectangleDrawer : EmguCVDrawer
    {
        public RectangleDrawer(Image<Bgr, byte> frame, TimePoint point)
            : base(frame, point)
        { }

        public override void Draw()
        {
            Rectangle rect = new Rectangle((int)Point.X, (int)Point.Y, 100, 100);
            Frame.Draw(rect, new Bgr(System.Drawing.Color.Red), 2);
        }
    }
}
