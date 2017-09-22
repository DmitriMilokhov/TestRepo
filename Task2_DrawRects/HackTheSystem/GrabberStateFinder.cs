using Emgu.CV;
using EmvuCV_VideoPlayer.Infrustructure;
using System.Reflection;

namespace EmvuCV_VideoPlayer.HackTheSystem
{
    public static class GrabberStateFinder
    {
        public static GrabStates GetGrabberThreadState(this VideoCapture capture)
        {
            FieldInfo fieldInfo = typeof(VideoCapture).GetField("_grabState", BindingFlags.Instance | BindingFlags.NonPublic);
            GrabStates result = (GrabStates)fieldInfo.GetValue(capture);
            return result;
        }
    }
}
