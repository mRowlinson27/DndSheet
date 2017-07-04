using System.Collections.Generic;
using System.Collections.Specialized;
using SqlDatabase.API;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDatabase : ISqLiteDatabase
    {
        private ISqLiteConnectionWrapper _sqLiteConnectionWrapper;

        public SqLiteDatabase(ISqLiteConnectionWrapper sqLiteConnectionWrapper)
        {
            _sqLiteConnectionWrapper = sqLiteConnectionWrapper;
        }

        public void CreateNewDatabase(string fileName)
        {
            _sqLiteConnectionWrapper.CreateFile(fileName);
        }

        public void Connect(string connection)
        {
            _sqLiteConnectionWrapper.Connect(connection);
        }

        public void ExecuteNonQuery(string sql)
        {
            _sqLiteConnectionWrapper.ExecuteNonQuery(sql);
        }

        public List<NameValueCollection> ExecuteReader(string sql)
        {
            var data = new List<NameValueCollection>();
            var dataReader = _sqLiteConnectionWrapper.ExecuteReader(sql);
            while (dataReader.Read())
            {
                data.Add(dataReader.GetValues());
            }
            return data;
        }
    }
}
