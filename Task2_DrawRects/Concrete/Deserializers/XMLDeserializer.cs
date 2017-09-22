using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.Concrete;
using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace EmvuCV_VideoPlayer.Concrete.Deserializers
{
    public class XMLDeserializer : IAdditionalObjectsDeserializable
    {
        public Tracks Deserialize(string path = "")
        {
            if (path == "")
            {
                path = Environment.CurrentDirectory + "\\tracks-cyprus.handmade.xml";
            }

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
