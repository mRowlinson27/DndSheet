using System;
using System.Collections.Generic;
using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    public class DataPointClient : IDataPointClient
    {
        private readonly IDataPoint _dataPoint;
        private object _value;
        private object _output;
        public object Output { get { return _output; } }
        private Dictionary<int, object> _subscriptions;

        public DataPointClient(IDataPoint dataPoint, object value)
        {
            _dataPoint = dataPoint;
            _value = value;
            _output = value;
            _subscriptions = new Dictionary<int, object>();
        }

        public void UnSubscribeTo(IDataPoint dataPoint)
        {
            if (_subscriptions.ContainsKey(dataPoint.Eid))
            {
                _subscriptions.Remove(dataPoint.Eid);
                dataPoint.Update -= ReceiveUpdate;
            }
            Update();
        }

        public void SubscribeTo(IDataPoint dataPoint, object currentChange)
        {
            if (currentChange.GetType() != _value.GetType())
            {
                throw new InvalidOperationException();
            }
            if (_value is string && _subscriptions.Count > 0)
            {
                throw new InvalidOperationException();
            }

            _subscriptions.Add(dataPoint.Eid, currentChange);
            dataPoint.Update += ReceiveUpdate;
            Update();
        }

        private void ReceiveUpdate(object sender, UpdateArgs updateArgs)
        {
            var server = sender as IDataPoint;
            if (server != null && updateArgs.Updates.ContainsKey(_dataPoint.Eid))
            {
                _subscriptions[server.Eid] = updateArgs.Updates[_dataPoint.Eid];
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
