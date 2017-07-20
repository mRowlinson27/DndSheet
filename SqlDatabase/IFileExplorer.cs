using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase
{
    public interface IFileExplorer
    {
        bool CheckFileExists(string fileName);
        void CreateNewDatabase(string filename);
        void DeleteFile(string filename);
    }
}
