using System;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace EmvuCV_VideoPlayer.Model
{
    [Serializable]
    public class TimePoint
    {
        [XmlAttribute("time")]
        [YamlMember(Alias = "time", ApplyNamingConventions = false)]
        public double Time { get; set; }

        [XmlAttribute("x")]
        [YamlMember(Alias = "x", ApplyNamingConventions = false)]
        public double X { get; set; } 

        [XmlAttribute("y")]
        [YamlMember(Alias = "y", ApplyNamingConventions = false)]
        public double Y { get; set; }

        public TimePoint(double time, double x, double y)
        {
            Time = time;
            X = x;
            Y = y;
        }

        public TimePoint() { }
    }
}
