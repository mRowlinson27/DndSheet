using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    public class TextBoxPropertiesStyle : ControlPropertiesStyle, ITextBoxPropertiesStyle
    {
        private bool _readOnly;
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; RecordPropertySet("ReadOnly"); } }
    }
}
