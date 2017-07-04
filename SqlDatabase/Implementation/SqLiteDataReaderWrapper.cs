using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDataReaderWrapper : ISqLiteDataReaderWrapper
    {
        private readonly SQLiteDataReader _sqLiteDataReader;

        public SqLiteDataReaderWrapper(SQLiteDataReader sqLiteDataReader)
        {
            _sqLiteDataReader = sqLiteDataReader;
        }

        public bool Read()
        {
            return _sqLiteDataReader.Read();
        }

        public NameValueCollection GetValues()
        {
            return _sqLiteDataReader.GetValues();
        }
    }
}
