using System.Collections.Generic;
using System.IO;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class ImportMetadata
    {
        public List<MetadataItem> ImportMetafiles(string path, ISerializer des)
        {
            var di = new DirectoryInfo(path);
            var list = new List<MetadataItem>();
            if (!di.Exists)
                return null;
            var diArr = di.GetDirectories();
            foreach (var dri in diArr)
            {
                var files = dri.GetFiles("*.xml");
                foreach (var file in files)
                {
                    list.Add(des.DeserializeFile<MetadataItem>(file.FullName));
                }
            }
            return list;
        }
    }
}
