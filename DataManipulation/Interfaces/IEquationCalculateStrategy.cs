using System;
using System.Collections.Generic;
using DataManipulation.DTO;

namespace DataManipulation.Interfaces
{
    public interface IEquationCalculateStrategy
    {
        string CalculateEquation(IPoint equation, List<Tuple<IPoint, PointEquation>> parentRelations);
    }
}
