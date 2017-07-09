using System;

namespace DataManipulation.DataPoint
{
    class TaggableInt
    {
        public int Eid { get; set; }
        public event EventHandler Update;
    }
}
