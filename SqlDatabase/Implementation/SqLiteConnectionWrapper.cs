using System;
using System.Data.SQLite;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteConnectionWrapper : ISqLiteConnectionWrapper
    {
        private string _connection;
        public void Connect(string connection)
        {
            _connection = connection;
        }

        public void CreateFile(string fileName)
        {
            SQLiteConnection.CreateFile(fileName);
        }

        public ISqLiteDataReaderWrapper ExecuteReader(string sql)
        {
            SqLiteDataReaderWrapper reader;
            using (var sqLiteConnection = new SQLiteConnection(_connection))
            {
                sqLiteConnection.Open();
                using (var command = new SQLiteCommand(sql, sqLiteConnection))
                {
                    reader = new SqLiteDataReaderWrapper(command.ExecuteReader());
                }
                sqLiteConnection.Close();
            }
            return reader;
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var sqLiteConnection = new SQLiteConnection(_connection))
            {
                sqLiteConnection.Open();
                using (var command = new SQLiteCommand(sql, sqLiteConnection))
                {
                    command.ExecuteNonQuery();
                }
                sqLiteConnection.Close();
            }
        }
    }
}
