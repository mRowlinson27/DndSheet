using System;
using DataManipulation.API;

namespace DataManipulation.EntryData
{
    class TaggableInt
    {
        public int Eid { get; set; }
        public event EventHandler Update;
    }
}
