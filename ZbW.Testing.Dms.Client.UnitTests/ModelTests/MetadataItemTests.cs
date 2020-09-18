using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.UnitTests.ModelTests
{
    [TestFixture]
    internal class MetadataItemTests
    {
        //arrange
        const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
        const string title = "TestBezeichnung";
        DateTime valutaDate = new DateTime(2010, 09, 10);
        const string type = "Quittungen";
        const string notes = "TestStichwort";
        DateTime entryDate = new DateTime(2020, 09, 10);
        const string username = "TestBenutzer";

        [Test]
        public void MetadataItem_create_ReturnsCorrectGuid()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.Guid.Equals("eb31d4ff-be0b-4366-9838-994ed803dd69"));
        }

        [Test]
        public void MetadataItem_create_ReturnsCorrectTitle()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.Title.Equals("TestBezeichnung"));
        }

        [Test]
        public void MetadataItem_create_ReturnsCorrectValutaDate()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.ValutaDate.Equals(new DateTime(2010, 09, 10)));
        }

        [Test]
        public void MetadataItem_create_ReturnsCorrectType()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.Type.Equals("Quittungen"));
        }

        [Test]
        public void MetadataItem_create_ReturnsCorrectNotes()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.Notes.Equals("TestStichwort"));
        }

        [Test]
        public void MetadataItem_create_ReturnsCorrectEntryDate()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.EntryDate.Equals(new DateTime(2020, 09, 10)));
        }

        [Test]
        public void MetadataItem_create_ReturnsCorrectUsername()
        {
            //act
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //assert
            Assert.That(metadata.Username.Equals("TestBenutzer"));
        }

        [Test]
        public void MetadataItem_toString_ReturnsCorrectString()
        {
            //arrange
            MetadataItem metadata = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);

            //act
            string result = metadata.ToString();

            //assert
            Assert.That(result, Is.EqualTo("TestBezeichnung, TestStichwort"));
        }
    }
}
