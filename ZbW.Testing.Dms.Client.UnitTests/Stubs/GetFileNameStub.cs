using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.Stubs
{
    internal class GetFileNameStub : IGetFileName
    {
        public string GetContentName(string filePath, string guid, string destPath)
        {
            return @"Testordner\Testfile2.txt";
        }

        public string GetMetadataName(string destPath, string guid)
        {
            return @"Testordner\Testfile.txt";
        }
    }
}
