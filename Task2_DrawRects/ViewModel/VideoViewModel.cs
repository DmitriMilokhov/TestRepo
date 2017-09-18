using Emgu.CV;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Infrustructure;
using EmvuCV_VideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace EmvuCV_VideoPlayer.ViewModel
{
    public class VideoViewModel : INotifyPropertyChanged
    {
        private Repository repository = new Repository();
        private Video video;
        private BitmapSource frame;
        private double timestamp;

        public VideoViewModel()
        {
            string fileName = repository.GetNameFromCommandArg("-video");
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Environment.CurrentDirectory + "\\wildlife.wmv";
            }
            this.video = new Video(fileName);
        }

        public string Name
        {
            get { return video.Name; }
            set
            {
                video.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public VideoCapture Capture
        {
            get { return video.Capture; }
            set
            {
                video.Capture = value;
                OnPropertyChanged("Capture");
            }
        }

        public BitmapSource Frame
        {
            get { return frame; }
            set
            {
                frame = value;
                OnPropertyChanged("Frame");
            }
        }

        public double Timestamp
        {
            get { return timestamp; }
            set
            {
                timestamp = value;
                OnPropertyChanged("Timestamp");
            }
        }

        private RelayCommand playVideoCommand;
        public RelayCommand PlayVideoCommand
        {
            get
            {
                return playVideoCommand ??
                    (playVideoCommand = new RelayCommand(obj =>
                    {
                        DispatcherTimer My_Timer = new DispatcherTimer();
                        int FPS = (int)Capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                        My_Timer.Interval = new TimeSpan(0,0,0,0,1000/FPS);
                        My_Timer.Tick += new EventHandler(My_Timer_Tick);
                        
                        My_Timer.Start();
                    },
                    (obj) => video.Capture != null));
            }
        }

        private void My_Timer_Tick(object sender, EventArgs e)
        {
            Timestamp = Math.Round(video.Timestamp / 1000, 2);
            if (Capture.QueryFrame() != null)
            {
                Image<Bgr, byte> currentImage = Capture.QueryFrame().ToImage<Bgr, byte>();
                Frame = ConvertBitmapToBitmapSource(currentImage.Bitmap);
            }
            else
            {
                ((DispatcherTimer)sender).Stop();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private BitmapSource ConvertBitmapToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height, 96, 96, PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
    }
}
