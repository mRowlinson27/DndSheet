using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;

namespace DataManipulation.API
{
    public interface IDataRestoreStrategy
    {
        void Restore(IDatabaseControl databaseControl);
    }
}
