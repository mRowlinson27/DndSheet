using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms.DTOs
{
    class TextBoxStyleSheet
    {
        public bool Enabled { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Padding Margin { get; set; }
        public DockStyle Dock { get; set; }
        public Color BackColor { get; set; }
        public bool AutoSize { get; set; }
        public BorderStyle BorderStyle { get; set; }
        public Cursor Cursor { get; set; }
        public AnchorStyles Anchor { get; set; }
    }
}
