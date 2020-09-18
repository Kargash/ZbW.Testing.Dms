using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ZbW.Testing.Dms.Client.Services
{
    public class XmlSer : ISerializer
    {
        #region Methods

        public bool SerializeFile(object obj, string path)
        {
            try
            {
                var serializer = new XmlSerializer(obj.GetType());
                var stream = new FileStream(path, FileMode.Create);
                serializer.Serialize(stream, obj);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public T DeserializeFile<T>(string source) where T : class
        {
            try
            {
                var reader = XmlReader.Create(source);
                {
                    var deserializer = new XmlSerializer(typeof(T));
                    var file = (T) deserializer.Deserialize(reader);
                    reader.Close();
                    return file;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
