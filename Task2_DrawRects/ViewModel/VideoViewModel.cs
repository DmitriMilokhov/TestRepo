using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.Concrete;
using EmvuCV_VideoPlayer.Infrustructure;
using EmvuCV_VideoPlayer.Concrete.Deserializers;
using EmvuCV_VideoPlayer.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using EmvuCV_VideoPlayer.View;

namespace EmvuCV_VideoPlayer.ViewModel
{
    internal class VideoViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Repository repository = new Repository();

        private string fileName;
        private Video video;
        private BitmapSource frame;
        private double timestamp;
        private Tracks tracks;
        private Dispatcher dispathcer;
        private Deserializators selectedSerializator;

        private RelayCommand playVideoCommand;
        private RelayCommand pauseVideoCommand;
        private RelayCommand openSettingWindowCommand;

        private bool isNameShowModeSelected = true;
        private bool isCoordinateShowModeSelected = true;

        #endregion

        #region Properties

        public VideoViewModel(Dispatcher UIDispatcher)
        {
            fileName = repository.GetNameFromCommandArg("-video");
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Environment.CurrentDirectory + "\\Everest.wmv";
            }

            video = new Video(fileName);
            dispathcer = UIDispatcher;
        }

        public string Name
        {
            get { return video.Name.Split('\\').Last(); }
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
            get { return Math.Round(timestamp / 1000, 2); }
            set
            {
                timestamp = value;
                OnPropertyChanged("Timestamp");
            }
        }

        public double Duration
        {
            get { return video.Duration; }
        }

        public Deserializators SelectedSerializator
        {
            get { return selectedSerializator; }
            set
            {
                selectedSerializator = value;
                OnPropertyChanged("SelectedSerializator");
            }
        }

        public bool IsNameShowModeSelected
        {
            get { return isNameShowModeSelected; }
            set
            {
                if (isNameShowModeSelected != value)
                {
                    isNameShowModeSelected = value;
                    OnPropertyChanged("IsNameShowModeSelected");
                }
            }
        }

        public bool IsCoordinateShowModeSelected
        {
            get { return isCoordinateShowModeSelected; }
            set
            {
                if (isCoordinateShowModeSelected != value)
                {
                    isCoordinateShowModeSelected = value;
                    OnPropertyChanged("IsCoordinateShowModeSelected");
                }
            }
        }

        #endregion

        #region Commands

        public RelayCommand PlayVideoCommand
        {
            get
            {
                return playVideoCommand ??
                    (playVideoCommand = new RelayCommand(obj =>
                    {
                        string serializationFilePath = "";
                        IAdditionalObjectsDeserializable serializer = SetSerializator(ref serializationFilePath);
                        tracks = serializer.Deserialize(serializationFilePath);

                        if (Capture.GetGrabberThreadState() != GrabStates.Pause)
                        {
                            Capture.Stop();
                            Thread.Sleep(10);
                            Capture.Dispose();
                            video = new Video(fileName);
                            Capture.ImageGrabbed += Capture_ImageGrabbed;
                        }

                        if(tracks != null)
                            Capture.Start();
                    },
                    (obj) => Capture.IsOpened));
            }
        }

        public RelayCommand PauseVideoCommand
        {
            get
            {
                return pauseVideoCommand ??
                    (pauseVideoCommand = new RelayCommand(obj =>
                    {
                        Capture.Pause();
                    },
                    (obj) => Capture.IsOpened));
            }
        }

        public RelayCommand OpenSettingWindowCommand
        {
            get
            {
                return openSettingWindowCommand ??
                    (openSettingWindowCommand = new RelayCommand(obj =>
                    {
                        SettingView settingView = new SettingView();
                        settingView.Show();
                    }));
            }
        }

        #endregion

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            Timestamp = video.CurrentTimestamp;
            Mat mCapture = new Mat();
            Capture.Retrieve(mCapture);
            if (mCapture != null)
            {
                try
                {
                    dispathcer.Invoke(() =>
                    {
                        Image<Bgr, byte> currentImage = mCapture.ToImage<Bgr, byte>();
                        DrawAdditionalObjects(currentImage);
                        Frame = repository.ConvertBitmapToBitmapSource(currentImage.Bitmap);
                        Thread.Sleep((int)Capture.GetCaptureProperty(CapProp.Fps));
                    });
                }
                catch (Exception ex) { }
            }
        }

        private void DrawAdditionalObjects(Image<Bgr, byte> imageToDraw)
        {
            EmguCVDrawer drawer;
            TimePoint currentPoint;
            if (tracks.Objects.Length > 0)
            {
                foreach (AdditionalObject obj in tracks.Objects)
                {
                    double[] timeValues = obj.Points.Select(p => p.Time).ToArray();
                    if (video.CurrentTimestamp >= timeValues.Min() && video.CurrentTimestamp <= timeValues.Max())
                    {
                        currentPoint = repository.LagrangeInterpolatePoint(video.CurrentTimestamp, obj.Points);
                        drawer = new RectangleDrawer(imageToDraw, currentPoint);

                        if (isCoordinateShowModeSelected)
                            drawer = new CoordinatedRectangleDrawer(drawer);
                        if (isNameShowModeSelected)
                            drawer = new NamedRectangleDrawer(drawer, obj.Name);
                        obj.Draw(drawer);
                    }
                }
            }
        }

        private IAdditionalObjectsDeserializable SetSerializator(ref string filePath)
        {
            ObservableCollection<SerializatorsSetting> serializationSettings = repository.LoadSettingsFromXml<SerializatorsSetting>();
            switch (selectedSerializator)
            {
                case Deserializators.XmlSerializator:
                    filePath = serializationSettings.FirstOrDefault(s => s.SeriaizatorType == Deserializators.XmlSerializator).FilePath;
                    return new XMLDeserializer();

                case Deserializators.YamlSerializator:
                    filePath = serializationSettings.FirstOrDefault(s => s.SeriaizatorType == Deserializators.YamlSerializator).FilePath;
                    return new YAMLDeserializer();
                default:
                    return new XMLDeserializer();
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
    }
}
