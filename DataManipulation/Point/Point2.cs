using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class Point2
    {
        private readonly IPointValue _value;
        private readonly Dictionary<int, IPointEquation> _subscribedEquations;
        public int Eid { get; set; }

        public Point2(int eid, IPointValue value)
        {
            _value = value;
            _subscribedEquations = new Dictionary<int, IPointEquation>();
            Eid = eid;
        }

        public void UnSubscribeTo(IPointEquation equation)
        {
            _subscribedEquations.Remove(equation.Eid);
        }

        public void SubscribeTo(IPointEquation equation)
        {
            _subscribedEquations.Add(equation.Eid, equation);
        }

        public string GetOutput()
        {
            var output = "";
            foreach (var equation in _subscribedEquations)
            {
                output = equation.Value.Evaluate(_value);
            }
            return output;
        }
    }
}
