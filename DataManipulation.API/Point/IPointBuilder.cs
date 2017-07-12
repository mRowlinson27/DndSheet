using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;

namespace DataManipulation.API.Point
{
    public interface IPointBuilder
    {
        IPoint BuildPoint(TableEntity tableEntity);
    }
}
