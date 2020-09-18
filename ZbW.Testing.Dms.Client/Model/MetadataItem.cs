using System;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        #region Properties

        public string Guid { get; set; }
        public string Title { get; set; }
        public DateTime ValutaDate { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public DateTime EntryDate { get; set; }
        public string Username { get; set; }

        #endregion

        #region Constructors

        public MetadataItem() { }

        public MetadataItem(string guid, string bezeichnung, DateTime valutaDate, string typ, string notes, DateTime entryDate, string username)
        {
            Guid = guid;
            Title = bezeichnung;
            ValutaDate = valutaDate;
            Type = typ;
            Notes = notes ?? "";
            EntryDate = entryDate;
            Username = username;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Title}, {Notes}";
        }

        #endregion
    }
}