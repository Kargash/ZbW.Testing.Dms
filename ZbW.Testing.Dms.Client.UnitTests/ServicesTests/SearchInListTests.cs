using System;
using System.Collections.Generic;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.UnitTests.ServicesTests
{
    [TestFixture]
    internal class SearchInListTests
    {
        [Test]
        public void SearchInList_correctInput_ReturnsfilledList()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem1 = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            MetadataItem testItem2 = new MetadataItem(guid, "Hallo", valutaDate, "Verträge", "ungültig", entryDate, username);
            MetadataItem testItem3 = new MetadataItem(guid, "Test", valutaDate, type, "", entryDate, username);
            List<MetadataItem> inputList = new List<MetadataItem> { testItem1, testItem2, testItem3 };
            SearchInList search = new SearchInList();

            //act
            List<MetadataItem> result = search.GetMatchingItems(inputList, "Test", "Quittungen");

            //assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Contains(testItem1));
            Assert.That(result.Contains(testItem3));
            Assert.That(!result.Contains(testItem2));
        }

        [Test]
        public void SearchInList_SearchTermNull_ReturnsListWithType()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem1 = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            MetadataItem testItem2 = new MetadataItem(guid, "Hallo", valutaDate, "Verträge", "ungültig", entryDate, username);
            MetadataItem testItem3 = new MetadataItem(guid, "Test", valutaDate, type, "", entryDate, username);
            List<MetadataItem> inputList = new List<MetadataItem> { testItem1, testItem2, testItem3 };
            SearchInList search = new SearchInList();

            //act
            List<MetadataItem> result = search.GetMatchingItems(inputList, null, "Verträge");

            //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.Contains(testItem2));
        }

        [Test]
        public void SearchInList_TypeNull_ReturnsListWithSearchTearm()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem1 = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            MetadataItem testItem2 = new MetadataItem(guid, title, valutaDate, "Verträge", "ungültig", entryDate, username);
            MetadataItem testItem3 = new MetadataItem(guid, "Test", valutaDate, type, "", entryDate, username);
            List<MetadataItem> inputList = new List<MetadataItem> { testItem1, testItem2, testItem3 };
            SearchInList search = new SearchInList();

            //act
            List<MetadataItem> result = search.GetMatchingItems(inputList, "Test" , null);

            //assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Contains(testItem1));
            Assert.That(result.Contains(testItem2));
            Assert.That(result.Contains(testItem3));
        }

        [Test]
        public void SearchInList_seachWithoutInput_ReturnsEmptyList()
        {
            //arrange
            const string guid = "eb31d4ff-be0b-4366-9838-994ed803dd69";
            const string title = "TestBezeichnung";
            DateTime valutaDate = new DateTime(2010, 09, 10);
            const string type = "Quittungen";
            const string notes = "TestStichwort";
            DateTime entryDate = new DateTime(2020, 09, 10);
            const string username = "TestBenutzer";
            MetadataItem testItem1 = new MetadataItem(guid, title, valutaDate, type, notes, entryDate, username);
            MetadataItem testItem2 = new MetadataItem(guid, title, valutaDate, "Verträge", "ungültig", entryDate, username);
            MetadataItem testItem3 = new MetadataItem(guid, "Test", valutaDate, type, "", entryDate, username);
            List<MetadataItem> inputList = new List<MetadataItem> { testItem1, testItem2, testItem3 };
            SearchInList search = new SearchInList();

            //act
            List<MetadataItem> result = search.GetMatchingItems(inputList, null, null);

            //assert
            Assert.That(result, Is.Empty);
        }
    }
}
