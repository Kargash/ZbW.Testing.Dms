using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.Stubs
{
    public class XmlSerStub : ISerializer
    {
        private readonly bool _isSerialized;

        public XmlSerStub(bool isSerialized)
        {
            _isSerialized = isSerialized;
        }

        public bool SerializeFile(object obj, string path)
        {
            return _isSerialized;
        }

        public T DeserializeFile<T>(string source) where T : class
        {
            return null;
        }
    }
}
