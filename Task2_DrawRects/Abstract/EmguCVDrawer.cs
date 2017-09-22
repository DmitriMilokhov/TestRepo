using Emgu.CV;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Model;

namespace EmvuCV_VideoPlayer.Abstract
{
    public abstract class EmguCVDrawer
    {
        public Image<Bgr, byte> Frame { get; protected set; }
        public TimePoint Point { get; protected set; }

        public EmguCVDrawer(Image<Bgr, byte> frame, TimePoint point)
        {
            Frame = frame;
            Point = point;
        }

        public abstract void Draw();
    }
}
