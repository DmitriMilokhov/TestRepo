using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmvuCV_VideoPlayer.Abstract
{
    interface IEmguCVDrawing
    {
        void Draw(VideoCapture capture);
    }
}
