using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace EmvuCV_VideoPlayer.Concrete
{
    [XmlRoot("objects_tracks_data")]
    public class Tracks
    {
        [XmlElement("vobj")]
        [YamlMember(Alias = "objects", ApplyNamingConventions = false)]
        public AdditionalObject[] Objects { get; set; }
    }
}
