using System;
using Emgu.CV;
using EmvuCV_VideoPlayer.Abstract;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace EmvuCV_VideoPlayer.Model
{   
    [Serializable]
    public class AdditionalObject : IEmguCVDrawing, INotifyPropertyChanged
    {
        private string name;
        private ObservableCollection<TimePoint> points;

        [XmlAttribute("name")]
        [YamlMember(Alias = "name", ApplyNamingConventions = false)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [XmlElement("point")]
        [YamlMember(Alias = "points", ApplyNamingConventions = false)]
        public ObservableCollection<TimePoint> Points
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }

        public void Draw(VideoCapture capture)
        {
            //
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
