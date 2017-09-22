using Emgu.CV;
using Emgu.CV.CvEnum;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmvuCV_VideoPlayer.Model
{
    public class Video : INotifyPropertyChanged
    {
        private string name;
        private VideoCapture capture;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public VideoCapture Capture
        {
            get { return capture; }
            set
            {
                capture = value;
                OnPropertyChanged("Capture");
            }
        }

        public double CurrentTimestamp
        {
            get { return capture.GetCaptureProperty(CapProp.PosMsec); }
        }

        public double Duration
        {
            get { return capture.GetCaptureProperty(CapProp.FrameCount) / capture.GetCaptureProperty(CapProp.Fps); }
        }

        public Video(string fileName)
        {
            name = fileName;
            capture = new VideoCapture(name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
