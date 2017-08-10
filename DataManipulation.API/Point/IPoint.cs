using System;
using System.Collections.Generic;

namespace DataManipulation.API.Point
{
    public interface IPoint : IDisposable
    {
        event EventHandler Updated;
        int Eid { get; set; }
        string Output { get; }
        void UpdateValue(string value);
        void UnSubscribeTo(int eid, IPointEquation equation);
        void SubscribeTo(int eid, IPointEquation equation);
    }
}
