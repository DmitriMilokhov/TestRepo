using Emgu.CV;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Infrustructure;
using EmvuCV_VideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Dispatcher UIDispatcher;

        public VideoViewModel(Dispatcher uiDispatcher)
        {
            string fileName = repository.GetNameFromCommandArg("-video");
            this.video = new Video(fileName);
            UIDispatcher = uiDispatcher;
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

        private RelayCommand playVideoCommand;
        public RelayCommand PlayVideoCommand
        {
            get
            {
                return playVideoCommand ??
                    (playVideoCommand = new RelayCommand(obj =>
                    {
                        VideoCapture currCapture = obj as VideoCapture;
                        currCapture.ImageGrabbed += Capture_ImageGrabbed;
                        currCapture.Start();
                    },
                    (obj) => video.Capture != null));
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            VideoCapture capture = sender as VideoCapture;
            if (capture != null)
            {
                Mat mat = new Mat();
                capture.Retrieve(mat);
                Image<Bgr, byte> currentImage = mat.ToImage<Bgr, byte>();
                UIDispatcher.Invoke(() => { Frame = ConvertBitmapToBitmapSource(currentImage.Bitmap);  });
                Thread.Sleep((int)capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
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
