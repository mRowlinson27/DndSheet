using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase
{
    public class FileExplorer : IFileExplorer
    {
        public bool CheckFileExists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
