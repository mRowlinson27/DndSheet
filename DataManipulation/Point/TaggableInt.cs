using System;

namespace DataManipulation.Point
{
    class TaggableInt
    {
        public int Eid { get; set; }
        public event EventHandler Update;
    }
}
