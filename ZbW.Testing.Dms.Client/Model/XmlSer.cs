using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ZbW.Testing.Dms.Client.Model
{
    public class XmlSer : ISerializer
    {
        public void SerializeFile(object obj, string path)
        {
            var serializer = new XmlSerializer(obj.GetType());
            var stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, obj);
            stream.Close();
        }

        public T DeserializeFile<T>(string source) where T : class
        {
            using (var reader = XmlReader.Create(source))
            {
                var deserializer = new XmlSerializer(typeof(T));
                return (T)deserializer.Deserialize(reader);
            }
        }

        //Todo: öööööööööööh was?
        //public void DeserializeFile(object obj, string source)
        //{
        //    var deserializer = new XmlSerializer(obj.GetType());
        //    using (Stream reader = new FileStream(source, FileMode.Open))
        //    {
        //        obj = (MetadataItem)deserializer.Deserialize(reader);
        //    }
        //}

    }
}
