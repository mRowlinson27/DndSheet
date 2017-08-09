using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DTOs;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class Point : IPoint
    {
        private readonly PointValue _value;
        private readonly Dictionary<int, IPointEquation> _subscribedEquations;
        public event EventHandler Updated;
        public int Eid { get; set; }
        private string _output;

        public Point(int eid, PointValue value)
        {
            _value = value;
            _output = _value.Value;
            _subscribedEquations = new Dictionary<int, IPointEquation>();
            Eid = eid;
        }

        public string Output => _output;

        public void UpdateValue(string value)
        {
            _value.Value = value;
            UpdateAndNotify();
        }

        public void UnSubscribeTo(IPointEquation equation)
        {
            _subscribedEquations.Remove(equation.Eid);
            equation.Updated -= OnEquationUpdated;
            UpdateAndNotify();
        }

        public void SubscribeTo(IPointEquation equation)
        {
            _subscribedEquations.Add(equation.Eid, equation);
            equation.Updated += OnEquationUpdated;
            UpdateAndNotify();
        }

        private void OnEquationUpdated(object sender, EventArgs eventArgs)
        {
            UpdateAndNotify();
        }

        private void UpdateAndNotify()
        {
            var newOutput = RecalculateOutput();
            if (newOutput != _output && Updated != null)
            {
                Updated.Invoke(this, EventArgs.Empty);
            }
            _output = newOutput;
        }

        private string RecalculateOutput()
        {
            var response = _value.Value;
            foreach (var equation in _subscribedEquations)
            {
                response = equation.Value.Evaluate(response, _value.DataType);
            }
            return response;
        }

        public void Dispose()
        {
            foreach (var equation in _subscribedEquations)
            {
                equation.Value.Updated -= OnEquationUpdated;
            }
        }
    }
}
