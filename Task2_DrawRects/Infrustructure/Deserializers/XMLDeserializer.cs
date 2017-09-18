using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.Model;
using System.Xml.Serialization;
using System.IO;

namespace EmvuCV_VideoPlayer.Infrustructure.Deserializers
{
    public class XMLDeserializer : IAdditionalObjectsDeserializable
    {
        public Tracks Deserialize(string path)
        {
            Tracks tracks = null;
            using (Stream fStream = new FileStream(path, FileMode.Open,
                 FileAccess.Read, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(Tracks));
                tracks = (Tracks)xmlFormat.Deserialize(fStream);
            }
            return tracks;
        }
    }
}
