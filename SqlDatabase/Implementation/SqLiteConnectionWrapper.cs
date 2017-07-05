using System;
using System.Data.SQLite;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteConnectionWrapper : ISqLiteConnectionWrapper
    {
        private string _connection;
        private SQLiteConnection _sqLiteConnection;

        public SqLiteConnectionWrapper(string connection)
        {
            _sqLiteConnection = new SQLiteConnection(connection);
        }

        public void Open()
        {
            _sqLiteConnection.Open();
        }

        public void Close()
        {
            _sqLiteConnection.Close();
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var command = new SQLiteCommand(sql, _sqLiteConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public ISqLiteDataReaderWrapper ExecuteReader(string sql)
        {
            ISqLiteDataReaderWrapper reader;
            using (var command = new SQLiteCommand(sql, _sqLiteConnection))
            {
                reader = new SqLiteDataReaderWrapper(command.ExecuteReader());
            }
            return reader;
        }

        public void Dispose()
        {
            _sqLiteConnection.Dispose();
        }
    }
}
