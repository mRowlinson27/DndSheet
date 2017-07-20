using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

        public void CreateNewDatabase(string filename)
        {
            SQLiteConnection.CreateFile(filename);
        }

        public void DeleteFile(string filename)
        {
            if (CheckFileExists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}
