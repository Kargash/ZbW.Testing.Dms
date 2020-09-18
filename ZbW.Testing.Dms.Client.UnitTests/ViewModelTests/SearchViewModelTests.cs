using System.Collections.Generic;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.UnitTests.ViewModelTests
{
    [TestFixture]
    internal class SearchViewModelTests
    {
        [Test]
        public void SearchViewModel_testReset_PropertiesSetToNull()
        {
            //arrange
            SearchViewModel search = new SearchViewModel(false);
            search.Suchbegriff = "Test";
            search.SelectedTypItem = "Verträge";
            search.FilteredMetadataItems = new List<MetadataItem> { new MetadataItem(), new MetadataItem() };

            //act
            search.OnCmdReset();
            string result1 = search.Suchbegriff;
            string result2 = search.SelectedTypItem;
            List<MetadataItem> result3 = search.FilteredMetadataItems;

            //assert
            Assert.That(result1, Is.Null);
            Assert.That(result2, Is.Null);
            Assert.That(result3, Is.Null);
        }
    }
}
