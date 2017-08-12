using System;
using DataManipulation.DTO;
using DataManipulation.Interfaces;

namespace DataManipulation
{
    public class Point : IPoint
    {
        public int Eid { get; set; }

        public string DataType
        {
            get
            {
                return _pointValue.DataType;
            }
            set
            {
                _pointValue.DataType = value;
                if (Updated != null)
                {
                    Updated.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string Value
        {
            get
            {
                return _pointValue.Value;
            }
            set
            {
                _pointValue.Value = value;
                if (Updated != null)
                {
                    Updated.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string Output { get; set; }
        
        public event EventHandler Updated;

        private PointValue _pointValue;

        public Point(int eid, PointValue value)
        {
            Eid = eid;
            _pointValue = value;
        }

        public void Update()
        {
            if (Updated != null)
            {
                Updated.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
