using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using SqlDatabase.API;

namespace DataManipulation
{
    public class DataMediator
    {
        private readonly IDatabase _database;
        private readonly IDataRestoreStrategy _dataRestoreStrategy;

        public DataMediator(IDatabase database, IDataRestoreStrategy dataRestoreStrategy)
        {
            _database = database;
            _dataRestoreStrategy = dataRestoreStrategy;
        }

        public void Restore()
        {
            //_dataRestoreStrategy.Restore(_databaseControl);
        }

        public void Save()
        {
            
        }
    }
}
