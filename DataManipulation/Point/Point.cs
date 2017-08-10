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
        private readonly Dictionary<Tuple<int,int>, IPointEquation> _subscribedEquations;
        public event EventHandler Updated;
        public int Eid { get; set; }
        private string _output;

        public Point(int eid, PointValue value)
        {
            _value = value;
            _output = _value.Value;
            _subscribedEquations = new Dictionary<Tuple<int, int>, IPointEquation>();
            Eid = eid;
        }

        public string Output => _output;

        public void UpdateValue(string value)
        {
            _value.Value = value;
            UpdateAndNotify();
        }

        public void UnSubscribeTo(int eid, IPointEquation equation)
        {
            _subscribedEquations.Remove(new Tuple<int, int>(eid, equation.Eid));
            equation.Updated -= OnEquationUpdated;
            UpdateAndNotify();
        }

        public void SubscribeTo(int eid,IPointEquation equation)
        {
            if (eid == Eid)
            {
                throw new ArgumentException();
            }
            _subscribedEquations.Add(new Tuple<int, int>(eid, equation.Eid), equation);
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
            var request = new EquationRequest()
            {
                Value = _value.Value,
                DataType = _value.DataType
            };
            foreach (var equation in _subscribedEquations)
            {
                request.SubscriberEid = equation.Key.Item1;
                var response = equation.Value.Evaluate(request);
                request.Value = response;
            }
            return request.Value;
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
