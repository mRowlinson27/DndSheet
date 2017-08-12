using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.DTO;
using DataManipulation.Interfaces;

namespace DataManipulation
{
    public class EquationCalculateStrategy : IEquationCalculateStrategy
    {
        public string CalculateEquation(IPoint equation, List<Tuple<IPoint, PointEquation>> parentRelations)
        {
            throw new NotImplementedException();
        }
    }
}
