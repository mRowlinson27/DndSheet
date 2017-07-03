using System.Data.SQLite;

namespace SqlDatabase.Interfaces
{
    public interface ISqLiteWrapper
    {
        void Create(string connection);
        void Connect(string connection);
        SQLiteDataReader Query(string query);
        void Insert(string query);
    }
}
