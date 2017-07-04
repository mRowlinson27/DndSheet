using System.Data.SQLite;
using SqlDatabase.Implementation;

namespace SqlDatabase.Interfaces
{
    public interface ISqLiteConnectionWrapper
    {
        void CreateFile(string connection);
        void Connect(string connection);
        ISqLiteDataReaderWrapper ExecuteReader(string sql);
        void ExecuteNonQuery(string sql);
    }
}
