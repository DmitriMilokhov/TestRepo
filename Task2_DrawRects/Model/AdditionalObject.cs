using System;
using Emgu.CV;
using EmvuCV_VideoPlayer.Abstract;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using Emgu.CV.Structure;
using System.Linq;
using EmvuCV_VideoPlayer.Infrustructure;
using System.Drawing;

namespace EmvuCV_VideoPlayer.Model
{
    [Serializable]
    public class AdditionalObject
    {
        private Repository repository = new Repository();

        [XmlAttribute("name")]
        [YamlMember(Alias = "name", ApplyNamingConventions = false)]
        public string Name { get; set; }

        [XmlElement("point")]
        [YamlMember(Alias = "points", ApplyNamingConventions = false)]
        public ObservableCollection<TimePoint> Points { get; set; }

        public AdditionalObject() { }

        public AdditionalObject(string name, ObservableCollection<TimePoint> points)
        {
            Name = name;
            Points = points;
        }

        public virtual void Draw(EmguCVDrawer drawer)
        {
            drawer.Draw();
        }
    }
}
