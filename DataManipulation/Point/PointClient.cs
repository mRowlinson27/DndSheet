using System;
using System.Collections.Generic;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointClient : IPointClient
    {
        private readonly IPoint _point;
        private object _value;
        private object _output;
        public object Output { get { return _output; } }
        private Dictionary<int, object> _subscriptions;

        public PointClient(IPoint point, object value)
        {
            _point = point;
            _value = value;
            _output = value;
            _subscriptions = new Dictionary<int, object>();
        }

        public void UnSubscribeTo(IPoint point)
        {
            if (_subscriptions.ContainsKey(point.Eid))
            {
                _subscriptions.Remove(point.Eid);
                point.Update -= ReceiveUpdate;
            }
            Update();
        }

        public void SubscribeTo(IPoint point, object currentChange)
        {
            if (currentChange.GetType() != _value.GetType())
            {
                throw new InvalidOperationException();
            }
            if (_value is string && _subscriptions.Count > 0)
            {
                throw new InvalidOperationException();
            }

            _subscriptions.Add(point.Eid, currentChange);
            point.Update += ReceiveUpdate;
            Update();
        }

        private void ReceiveUpdate(object sender, UpdateArgs updateArgs)
        {
            var server = sender as IPoint;
            if (server != null && updateArgs.Updates.ContainsKey(_point.Eid))
            {
                _subscriptions[server.Eid] = updateArgs.Updates[_point.Eid];
            }
            Update();
        }

        private void Update()
        {
            _output = _value;
            foreach (var currentValue in _subscriptions.Values)
            {
                if (currentValue is string)
                {
                    _output = currentValue;
                }
                if (currentValue is int && _output is int)
                {
                    _output = (int) _output + (int) currentValue;
                }
            }
        }
    }
}
