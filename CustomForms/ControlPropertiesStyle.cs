using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    public class ControlPropertiesStyle : IControlPropertiesStyle
    {
        private bool _enabled;
        public bool Enabled { get { return _enabled; } set { _enabled = value; RecordPropertySet("Enabled"); } }

        public IntPtr Handle { get; }

        private int _height;
        public int Height { get { return _height; } set { _height = value; RecordPropertySet("Height"); } }

        private int _width;
        public int Width { get { return _width; } set { _width = value; RecordPropertySet("Width"); } }

        private Padding _margin;
        public Padding Margin { get { return _margin; } set { _margin = value; RecordPropertySet("Margin"); } }

        private DockStyle _dock;
        public DockStyle Dock { get { return _dock; } set { _dock = value; RecordPropertySet("Dock"); } }

        private Color _backColor;
        public Color BackColor { get { return _backColor; } set { _backColor = value; RecordPropertySet("BackColor"); } }

        private bool _autoSize;
        public bool AutoSize { get { return _autoSize; } set { _autoSize = value; RecordPropertySet("AutoSize"); } }

        private BorderStyle _borderStyle;
        public BorderStyle BorderStyle { get { return _borderStyle; } set { _borderStyle = value; RecordPropertySet("BorderStyle"); } }

        private Cursor _cursor;
        public Cursor Cursor { get { return _cursor; } set { _cursor = value; RecordPropertySet("Cursor"); } }

        private AnchorStyles _anchor;
        public AnchorStyles Anchor { get { return _anchor; } set { _anchor = value; RecordPropertySet("Anchor"); } }

        private Font _font;
        public Font Font { get { return _font; } set { _font = value; RecordPropertySet("Font"); } }

        private string _text;
        public string Text { get { return _text; } set { _text = value; RecordPropertySet("Text"); } }

        public bool HasPropertyChanged(string property)
        {
            if (_changedProperties.Contains(property))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> _changedProperties = new List<string>();

        internal void RecordPropertySet(string property)
        {
            if (!_changedProperties.Contains(property))
            {
                _changedProperties.Add(property);
            } 
        }
    }
}
