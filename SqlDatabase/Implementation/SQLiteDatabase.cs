using System.Collections.Generic;
using System.Collections.Specialized;
using SqlDatabase.API;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDatabase : ISqLiteDatabase
    {
        private readonly ISqLiteConnectionWrapperFactory _sqLiteConnectionWrapperFactory;
        private string _connection;

        public SqLiteDatabase(string connection, ISqLiteConnectionWrapperFactory sqLiteConnectionWrapperFactory)
        {
            _connection = "Data Source=" + connection;
            _sqLiteConnectionWrapperFactory = sqLiteConnectionWrapperFactory;
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var sqLiteConnection = _sqLiteConnectionWrapperFactory.Create(_connection))
            {
                sqLiteConnection.Open();
                sqLiteConnection.ExecuteNonQuery(sql);
                sqLiteConnection.Close();
            }
        }

        public List<NameValueCollection> ExecuteReader(string sql)
        {
            ISqLiteDataReaderWrapper dataReader;
            var data = new List<NameValueCollection>();
            using (var sqLiteConnection = _sqLiteConnectionWrapperFactory.Create(_connection))
            {
                sqLiteConnection.Open();
                dataReader = sqLiteConnection.ExecuteReader(sql);
                while (dataReader.Read())
                {
                    data.Add(dataReader.GetValues());
                }
                sqLiteConnection.Close();
            }
            return data;
        }
    }
}
