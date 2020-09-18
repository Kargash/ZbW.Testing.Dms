using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;

    public class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _allItems;

        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        [ExcludeFromCodeCoverage]
        public SearchViewModel(bool isNotATest)
        {
            TypItems = ComboBoxItems.Typ;
            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
            if (isNotATest)
                LoadData();
        }

        [ExcludeFromCodeCoverage]
        public DelegateCommand CmdOeffnen { get; }

        [ExcludeFromCodeCoverage]
        public DelegateCommand CmdSuchen { get; }

        [ExcludeFromCodeCoverage]
        public DelegateCommand CmdReset { get; }

        [ExcludeFromCodeCoverage]
        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        [ExcludeFromCodeCoverage]
        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            var selectedPath = ConfigurationManager.AppSettings.Get("RepositoryDir") + @"\" + SelectedMetadataItem.ValutaDate.Year;
            var di = new DirectoryInfo(selectedPath);
            var files = di.GetFiles("*_Content.*");
            foreach (var file in files)
            {
                if (file.FullName.Contains(SelectedMetadataItem.Guid))
                {
                    System.Diagnostics.Process.Start(file.FullName);
                }
            }
        }

        private void OnCmdSuchen()
        {
            FilteredMetadataItems = _allItems;
            var search = new SearchInList();
            FilteredMetadataItems = search.GetMatchingItems(FilteredMetadataItems, Suchbegriff, SelectedTypItem);
        }

        public void OnCmdReset()
        {
            Suchbegriff = null;
            SelectedTypItem = null;
            FilteredMetadataItems = _allItems;
        }

        private void LoadData()
        {
            var directoryPath = ConfigurationManager.AppSettings.Get("RepositoryDir");
            var imp = new ImportMetadata();
            _allItems = imp.ImportMetafiles(directoryPath, new XmlSer());
            FilteredMetadataItems = _allItems;
        }
    }
}