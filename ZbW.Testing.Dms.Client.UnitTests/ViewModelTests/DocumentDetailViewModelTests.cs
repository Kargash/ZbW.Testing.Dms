using System;
using System.IO;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;
using ZbW.Testing.Dms.Client.UnitTests.Stubs;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModelTests
{
    [TestFixture]
    internal class DocumentDetailViewModelTests
    {
        [OneTimeSetUp]
        public void InitializeDirectories()
        {
            Directory.CreateDirectory("Testordner");
            FileStream create = File.Create(@"Testordner\Testfile.txt");
            create.Close();
        }

        [Test]
        public void SaveXml_NoFileSelected_ReturnsFalse()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = "Testpfad";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            //act
            bool result = doc.SaveXml(path, guid, new GetFileName(), new ShowMessageBoxStub(), new XmlSer());

            //assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void SaveXml_wrongInput_ReturnsFalse()
        {
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = "Testpfad";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            doc.FilePath = @"Testordner\Testfile.txt";
            //act
            bool result = doc.SaveXml(path, guid, new GetFileName(), new ShowMessageBoxStub(), new XmlSer());

            //assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void SaveXml_correctInput_ReturnsTrue()
        {
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = "Testordner";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            doc.FilePath = @"Testordner\Testfile.txt";
            doc.Bezeichnung = "Test";
            doc.ValutaDatum = new DateTime(2020, 10, 10);
            doc.SelectedTypItem = "Verträge";

            //act
            bool result = doc.SaveXml(path, guid, new GetFileName(), new ShowMessageBoxStub(), new XmlSerStub(true));

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void SaveDocument_testExistingFile_ReturnsFalse()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = @"Testordner\Testfile.txt";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            doc.FilePath = "Inexistent.txt";

            //act
            bool result = doc.SaveDocument(new GetFileName(), path, guid);

            //assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void SaveDocument_testMove_ReturnsTrue()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = "Testordner";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            doc.FilePath = @"Testordner\Testfile.txt";
            doc.IsRemoveFileEnabled = true;

            //act
            bool result = doc.SaveDocument(new GetFileName(), path, guid);

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void SaveDocument_testCopy_ReturnsTrue()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = "Testordner";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            doc.FilePath = @"Testordner\Testfile.txt";

            //act
            bool result = doc.SaveDocument(new GetFileNameStub(), path, guid);

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void SaveDocument_testException_ReturnsFalse()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string username = "TestBenutzer";
            const string path = @"Testordner\Inexistent\KeinZiel";
            DocumentDetailViewModel doc = new DocumentDetailViewModel(username, null);
            doc.FilePath = @"Testordner\Testfile.txt";

            //act
            bool result = doc.SaveDocument(new GetFileName(), path, guid);

            //assert
            Assert.That(result, Is.False);
        }


        [OneTimeTearDown]
        public void DeleteFolder()
        {
            Directory.Delete("Testordner", true);
        }
    }
}
