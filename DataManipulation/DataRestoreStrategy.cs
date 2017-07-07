using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using SqlDatabase.API;

namespace DataManipulation
{
    public class DataRestoreStrategy : IDataRestoreStrategy
    {
        public DataRestoreStrategy()
        {
            
        }

        public void Restore(IDatabaseControl databaseControl)
        {
            var test = databaseControl.FindEntitiesByDatatype("Heading");
        }
    }
}
