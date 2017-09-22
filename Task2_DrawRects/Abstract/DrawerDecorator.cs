using Emgu.CV;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Abstract
{
    public abstract class DrawerDecorator : EmguCVDrawer
    {
        protected EmguCVDrawer drawer;
        public DrawerDecorator(Image<Bgr, byte> frame, TimePoint point, EmguCVDrawer drawer)
            : base(frame, point)
        {
            this.drawer = drawer;
        }
    }
}
