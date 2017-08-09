using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DTOs;
using SqlDatabase.API.DTO;

namespace DataManipulation.API.Point
{
    public interface IPointBuilder
    {
        IPoint BuildExistingPoint(int eid, PointValue value, List<IPointEquation> equations);
    }
}
