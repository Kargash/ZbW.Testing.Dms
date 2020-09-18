using System;
using System.IO;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.ServicesTests
{
    [TestFixture]
    internal class XmlSerTests
    {
        [OneTimeSetUp]
        public void InitializeDirectories()
        {
            Directory.CreateDirectory("Testordner");
        }

        [Test]
        public void XmlSer_testSerialize_ReturnTrue()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            XmlSer ser = new XmlSer();

            //act
            bool result = ser.SerializeFile(testItem, "Testordner\\Serialisierung.xml");

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void XmlSer_testSerialize_Returnfalse()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            XmlSer ser = new XmlSer();

            //act
            bool result = ser.SerializeFile(testItem, "Testordner");

            //assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void XmlSer_testDeserialize_ReturnsCorrectProperties()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            XmlSer des = new XmlSer();
            des.SerializeFile(testItem, "Testordner\\Deserialisierung.xml");

            //act
            MetadataItem result = des.DeserializeFile<MetadataItem>("Testordner\\Deserialisierung.xml");

            //assert
            Assert.That(result, Is.TypeOf<MetadataItem>());
            Assert.That(result.Guid, Is.EqualTo("eb31d4ff-be0b-4366-9838-994ed803dd69"));
            Assert.That(result.Title, Is.EqualTo("TestBezeichnung"));
            Assert.That(result.ValutaDate, Is.EqualTo(new DateTime(2010, 09, 10)));
            Assert.That(result.Type, Is.EqualTo("Quittungen"));
            Assert.That(result.Notes, Is.EqualTo("TestStichwort"));
            Assert.That(result.EntryDate, Is.EqualTo(new DateTime(2020, 09, 10)));
            Assert.That(result.Username, Is.EqualTo("TestBenutzer"));
        }

        [Test]
        public void XmlSer_testDeserializeWithoutFile_ReturnsNull()
        {
            //arrange
            XmlSer des = new XmlSer();

            //act
            MetadataItem result = des.DeserializeFile<MetadataItem>("Testordner");

            //assert
            Assert.That(result, Is.Null);
        }

        [OneTimeTearDown]
        public void DeleteFolder()
        {
            Directory.Delete("Testordner", true);
        }
    }
}
