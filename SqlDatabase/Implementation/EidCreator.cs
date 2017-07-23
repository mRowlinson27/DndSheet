using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class EidCreator : IEidCreator
    {
        private readonly IDatabase _database;
        private readonly ISqlQueryConstructor _sqlQueryConstructor;

        public EidCreator(IDatabase database, ISqlQueryConstructor sqlQueryConstructor)
        {
            _database = database;
            _database.Connected += OnDatabaseConnected;
            _sqlQueryConstructor = sqlQueryConstructor;
        }

        private void OnDatabaseConnected(object sender, EventArgs eventArgs)
        {
            var sql = _sqlQueryConstructor.FindAllEids();
        }

        public int GetNextEid()
        {
            throw new NotImplementedException();
        }

        public List<int> GetNextXEids(int x)
        {
            throw new NotImplementedException();
        }
    }
}
