using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Model
{
    class ImportMetadata
    {
        //todo: eeeeeeeeeverythiiiiiiing
        public void ImportMetaitems(ISerializer ser, string path, List<MetadataItem> list)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diArr = di.GetDirectories();
            List<string> files = null;
            foreach (var dri in diArr)
            {
                files.Add(Directory.GetFiles(dri.FullName, "*.xml").ToString());
            }
            foreach (var file in files)
            {
                list.Add(ser.DeserializeFile<MetadataItem>(file));
            }
        }
    }
}
