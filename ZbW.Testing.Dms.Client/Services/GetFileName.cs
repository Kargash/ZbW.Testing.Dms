namespace ZbW.Testing.Dms.Client.Services
{
    public class GetFileName : IGetFileName
    {
        public string GetContentName(string filePath, string guid, string destPath)
        {
            var ending = filePath.Substring(filePath.LastIndexOf("."));
            return $@"{destPath}\{guid}_Content{ending}";
        }

        public string GetMetadataName(string destPath, string guid)
        {
            return $@"{destPath}\{guid}_Metadata.xml";
        }
    }
}
