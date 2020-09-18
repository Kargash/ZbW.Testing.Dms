using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Repositories;

    public class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;
        
        [ExcludeFromCodeCoverage]
        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;

            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }

        public string FilePath { get; set; }

        [ExcludeFromCodeCoverage]
        public string Stichwoerter
        {
            get
            {
                return _stichwoerter;
            }

            set
            {
                SetProperty(ref _stichwoerter, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }

            set
            {
                SetProperty(ref _bezeichnung, value);
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
        public DateTime Erfassungsdatum
        {
            get
            {
                return _erfassungsdatum;
            }

            set
            {
                SetProperty(ref _erfassungsdatum, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public DelegateCommand CmdDurchsuchen { get; }

        [ExcludeFromCodeCoverage]
        public DelegateCommand CmdSpeichern { get; }

        [ExcludeFromCodeCoverage]
        public DateTime? ValutaDatum
        {
            get
            {
                return _valutaDatum;
            }

            set
            {
                SetProperty(ref _valutaDatum, value);
            }
        }

        [ExcludeFromCodeCoverage]
        public bool IsRemoveFileEnabled
        {
            get
            {
                return _isRemoveFileEnabled;
            }

            set
            {
                SetProperty(ref _isRemoveFileEnabled, value);
            }
        }

        [ExcludeFromCodeCoverage]
        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result.GetValueOrDefault())
            {
                FilePath = openFileDialog.FileName;
            }
        }

        private void OnCmdSpeichern()
        {
            var guidString = Guid.NewGuid().ToString();
            var directoryPath = ConfigurationManager.AppSettings.Get("RepositoryDir");
            var path = Directory.CreateDirectory(directoryPath + @"\" + ValutaDatum?.Year).FullName;

            if (SaveXml(path, guidString, new GetFileName(),new ShowMessageBox(), new XmlSer()))
            {
                SaveDocument(new GetFileName(), path, guidString);
                _navigateBack();
            }
        }

        public bool SaveDocument(IGetFileName getName, string destPath, string guid)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var destName = getName.GetContentName(FilePath, guid, destPath);
                    if (IsRemoveFileEnabled)
                    {
                        File.Move(FilePath, destName);
                        return true;
                    }
                    File.Copy(FilePath, destName);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SaveXml(string destPath, string guid, IGetFileName getName, IMessage mb, ISerializer ser)
        {
            if (!IsFileSelected())
            {
                mb.ShowMessage("Keine Datei ausgewählt!");
                return false;
            }
            if (AreRequiredFieldsValid())
            {
                var newItem = new MetadataItem(guid, Bezeichnung, (DateTime)ValutaDatum, SelectedTypItem, Stichwoerter, Erfassungsdatum, Benutzer);
                var fileName = getName.GetMetadataName(destPath, guid);
                ser.SerializeFile(newItem, fileName);
                return true;
            }
            mb.ShowMessage("Es müssen alle Pflichtfelder ausgefüllt werden!");
            return false;
        }

        private bool AreRequiredFieldsValid()
        {
            return (!string.IsNullOrEmpty(Bezeichnung) && ValutaDatum != null && !string.IsNullOrEmpty(SelectedTypItem));
        }

        private bool IsFileSelected()
        {
            if (string.IsNullOrEmpty(FilePath))
                return false;
            return true;
        }
    }
}