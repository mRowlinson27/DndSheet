using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;

namespace DataManipulation.API.DataPoint
{
    public interface IDataPointBuilder
    {
        IDataPoint BuildPoint(TableEntity tableEntity);
    }
}
