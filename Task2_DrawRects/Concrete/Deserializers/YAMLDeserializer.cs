using EmvuCV_VideoPlayer.Abstract;
using EmvuCV_VideoPlayer.Concrete;
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace EmvuCV_VideoPlayer.Concrete.Deserializers
{
    class YAMLDeserializer : IAdditionalObjectsDeserializable
    {
        public Tracks Deserialize(string path="")
        {
            if (path == "")
            {
                path = Environment.CurrentDirectory + "\\cyprus.tracks.yaml";
            }

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
