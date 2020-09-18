namespace ZbW.Testing.Dms.Client.Services
{
    public interface ISerializer
    {
        bool SerializeFile(object obj, string path);

        T DeserializeFile<T>(string source) where T : class;
    }
}
