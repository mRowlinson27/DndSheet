using System;
using System.Data.SQLite;
using SqlDatabase.Implementation;

namespace SqlDatabase.Interfaces
{
    public interface ISqLiteConnectionWrapper : IDisposable
    {
        void Open();
        void Close();
        void ExecuteNonQuery(string sql);
        ISqLiteDataReaderWrapper ExecuteReader(string sql);
    }
}
