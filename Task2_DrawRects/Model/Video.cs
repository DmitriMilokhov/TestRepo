using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EmvuCV_VideoPlayer.Model
{
    public class Video : INotifyPropertyChanged
    {
        private string name;
        private VideoCapture capture;
        private double timestamp;

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

        public double Timestamp
        {
            get { return capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosMsec); }
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
