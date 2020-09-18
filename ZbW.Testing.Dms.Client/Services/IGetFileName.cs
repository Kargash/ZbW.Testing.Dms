namespace ZbW.Testing.Dms.Client.Services
{
    public interface IGetFileName
    {
        string GetContentName(string filePath, string guid, string destPath);
        string GetMetadataName(string destPath, string guid);
    }
}
