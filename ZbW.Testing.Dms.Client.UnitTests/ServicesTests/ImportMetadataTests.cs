using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.UnitTests.Stubs;

namespace ZbW.Testing.Dms.Client.UnitTests.ServicesTests
{
    [TestFixture]
    internal class ImportMetadataTests
    {
        [OneTimeSetUp]
        public void InitializeFiles()
        {
            Directory.CreateDirectory("Testordner\\Testfiles");
            Directory.CreateDirectory("Testordner\\Testempty");
            FileStream file1 = File.Create("Testordner\\Testfiles\\File1.xml");
            FileStream file2 = File.Create("Testordner\\Testfiles\\File2.xml");
            FileStream file3 = File.Create("Testordner\\Testfiles\\File3.xml");
            file1.Close();
            file2.Close();
            file3.Close();
        }

        [Test]
        public void ImportMetadata_DoesDirectoryExist_ReturnsNull()
        {
            //arrange
            const string path = "C:\\einTestPfad";
            ImportMetadata import = new ImportMetadata();

            //act
            List<MetadataItem> result = import.ImportMetafiles(path, new XmlSer());

            //assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ImportMetadata_DirectoryExist_ReturnsEmpty()
        {
            //arrange
            const string path = "Testordner\\Testempty";
            ImportMetadata import = new ImportMetadata();

            //act
            List<MetadataItem> result = import.ImportMetafiles(path, new XmlSer());

            //assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ImportMetadata_ImportList_ReturnsList()
        {
            //arrange
            const string path = "Testordner";
            ImportMetadata import = new ImportMetadata();

            //act
            List<MetadataItem> result = import.ImportMetafiles(path, new XmlSerStub(true));

            //assert
            Assert.That(result, Is.EqualTo(new List<MetadataItem> { null, null, null }));
        }

        [OneTimeTearDown]
        public void DeleteFolder()
        {
            Directory.Delete("Testordner", true);
        }

    }
}
