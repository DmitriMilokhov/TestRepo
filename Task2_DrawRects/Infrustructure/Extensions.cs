using Emgu.CV;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace EmvuCV_VideoPlayer.Infrustructure
{
    public static class Extensions
    {
        public static GrabStates GetGrabberThreadState(this VideoCapture capture)
        {
            FieldInfo fieldInfo = typeof(VideoCapture).GetField("_grabState", BindingFlags.Instance | BindingFlags.NonPublic);
            GrabStates result = (GrabStates)fieldInfo.GetValue(capture);
            return result;
        }

        public static string ToText(this Deserializators deserializator)
        {
            switch (deserializator)
            {
                case Deserializators.XmlSerializator:
                    return "XML Deserializator";
                case Deserializators.YamlSerializator:
                    return "YAML Deserializator";
                default:
                    return "";
            }
        }

        public static void SaveToXml<T>(this ObservableCollection<T> serializationSettings)
        {
            using (Stream fStream = new FileStream("Settings.xml", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<T>));
                xmlFormat.Serialize(fStream, serializationSettings);
            }
        }
    }
}
