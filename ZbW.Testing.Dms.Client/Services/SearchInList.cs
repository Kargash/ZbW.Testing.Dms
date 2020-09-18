using System.Collections.Generic;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class SearchInList
    {
        public List<MetadataItem> GetMatchingItems(List<MetadataItem> list, string suchbegriff, string typ)
        {
            var temp = new List<MetadataItem>();

            foreach (var item in list)
            {
                if (suchbegriff != null && typ != null)
                {
                    if (item.ToString().Contains(suchbegriff) && typ == item.Type)
                        temp.Add(item);
                }
                else if (suchbegriff != null)
                {
                    if (item.ToString().Contains(suchbegriff))
                        temp.Add(item);
                }
                else if (typ != null)
                {
                    if (typ == item.Type)
                        temp.Add(item);
                }
            }
            return temp;
        }
    }
}
