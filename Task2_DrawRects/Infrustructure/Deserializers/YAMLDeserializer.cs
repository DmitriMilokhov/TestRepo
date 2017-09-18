using EmvuCV_VideoPlayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmvuCV_VideoPlayer.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;

namespace EmvuCV_VideoPlayer.Infrustructure.Deserializers
{
    class YAMLDeserializer : IAdditionalObjectsDeserializable
    {
        public Tracks Deserialize(string path)
        {
            string text = File.ReadAllText(path);
            text = text.Replace("%YAML:1.0", "");
            text = text.Replace(":", ": ");

            StringReader input = new StringReader(text);
            Deserializer deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();
            Tracks tracks = deserializer.Deserialize<Tracks>(input);
            return tracks ?? null;
        }
    }
}
