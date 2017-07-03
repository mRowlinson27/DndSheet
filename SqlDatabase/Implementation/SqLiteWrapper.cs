using System;
using System.Data.SQLite;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteWrapper : ISqLiteWrapper, IDisposable
    {
        private SQLiteConnection _sqLiteConnection;
        public void Create(string connection)
        {
            SQLiteConnection.CreateFile(connection);
        }

        public void Connect(string connection)
        {
            _sqLiteConnection = new SQLiteConnection(connection);
        }

        public SQLiteDataReader Query(string query)
        {
            var command = new SQLiteCommand(query, _sqLiteConnection);
            var reader = command.ExecuteReader();
            return reader;
        }

        public void Insert(string query)
        {
            var command = new SQLiteCommand(query,_sqLiteConnection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _sqLiteConnection.Dispose();
        }
    }
}
