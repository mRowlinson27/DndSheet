using System;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms.DTOs
{
    public class ControlPropertiesStyle : IControlProperties
    {
        public bool Enabled { get; set; }
        public IntPtr Handle { get; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Padding Margin { get; set; }
        public DockStyle Dock { get; set; }
        public Color BackColor { get; set; }
        public bool AutoSize { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public Cursor Cursor { get; set; }
        public AnchorStyles Anchor { get; set; }
        public Font Font { get; set; }
        public string Text { get; set; }
    }
}
