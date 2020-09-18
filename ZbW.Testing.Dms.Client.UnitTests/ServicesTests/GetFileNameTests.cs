using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.ServicesTests
{
    [TestFixture]
    internal class GetFileNameTests
    {
        [Test]
        public void GetFileName_getContent_ReturnsCorrectString()
        {
            //arrange
            GetFileName name = new GetFileName();
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string filePath = "Testpfad.txt";
            const string destPath = "Testpfad";

            //act
            string result = name.GetContentName(filePath, guid, destPath);

            //assert
            Assert.That(result, Is.EqualTo(@"Testpfad\eb31d4ff-be0b-4366-9838-994ed803dd69_Content.txt"));
        }

        [Test]
        public void GetFileName_getMetadata_ReturnsCorrectString()
        {
            GetFileName name = new GetFileName();
            string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            string destPath = "Testpfad";

            //act
            string result = name.GetMetadataName(destPath, guid);

            //assert
            Assert.That(result, Is.EqualTo(@"Testpfad\eb31d4ff-be0b-4366-9838-994ed803dd69_Metadata.xml"));
        }
    }
}
