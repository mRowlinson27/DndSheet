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
        private readonly IDatabaseControl _databaseControl;
        private readonly IDataRestoreStrategy _dataRestoreStrategy;

        public DataMediator(IDatabaseControl databaseControl, IDataRestoreStrategy dataRestoreStrategy)
        {
            _databaseControl = databaseControl;
            _dataRestoreStrategy = dataRestoreStrategy;
        }

        public void Restore()
        {
            _dataRestoreStrategy.Restore(_databaseControl);
        }

        public void Save()
        {
            
        }
    }
}
