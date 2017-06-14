using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API
{
    public interface IControlProperties
    {
        bool Enabled { get; set; }
        IntPtr Handle { get; }
        int Height { get; set; }
        int Width { get; set; }
        Padding Margin { get; set; }
        DockStyle Dock { get; set; }
        Color BackColor { get; set; }
        bool AutoSize { get; set; }
        BorderStyle BorderStyle { get; set; }
        Cursor Cursor { get; set; }
        AnchorStyles Anchor { get; set; }
        Font Font { get; set; }
        string Text { get; set; }
    }
}
