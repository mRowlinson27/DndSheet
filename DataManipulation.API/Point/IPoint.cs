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
        void UnSubscribeTo(IPointEquation equation);
        void SubscribeTo(IPointEquation equation);
    }
}
