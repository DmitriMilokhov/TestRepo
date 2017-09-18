using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace EmvuCV_VideoPlayer.Model
{
    [Serializable]
    public class TimePoint
    {
        private int time;
        private int x;
        private int y;

        [XmlAttribute("time")]
        [YamlMember(Alias = "time", ApplyNamingConventions = false)]
        public int Time
        {
          get { return time; }
          set { time = value; }
        }

        [XmlAttribute("x")]
        [YamlMember(Alias = "x", ApplyNamingConventions = false)]
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        [XmlAttribute("y")]
        [YamlMember(Alias = "y", ApplyNamingConventions = false)]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public TimePoint(int time, int x, int y)
        {
            this.time = time;
            this.x = x;
            this.y = y;
        }

        public TimePoint() { }
    }
}
