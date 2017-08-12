using DataManipulation.API.DTOs;

namespace DataManipulation.Interfaces
{
    public interface IPointEquation
    {
        int Eid { get; set; }
        string Value { get; set; }
        string CalculateEquation(IPoint owner);
        string Evaluate(EquationRequest request);
    }
}
