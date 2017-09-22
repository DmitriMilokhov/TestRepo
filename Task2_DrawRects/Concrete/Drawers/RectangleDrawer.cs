using Emgu.CV;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.Model;
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
