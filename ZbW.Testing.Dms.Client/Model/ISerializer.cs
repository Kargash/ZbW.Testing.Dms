using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Model
{
    public interface ISerializer
    {
        void SerializeFile(object obj, string path);

        T DeserializeFile<T>(string source) where T : class;

        //void DeserializeFile(object obj, string source);
    }
}
