using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.API.Factories;
using CustomForms.DTOs;

namespace CustomForms.Factories
{
    public class ControlPropertiesFactory : IControlPropertiesFactory
    {
        public IControlProperties Create()
        {
            return new ControlPropertiesStyle();
        }

        public ITextboxProperties CreateTextboxInEditStyle()
        {
            var inEditStyle = new TextboxPropertiesStyle()
            {
                BackColor = Color.White
            };

            return inEditStyle;
        }

        public ITextboxProperties CreateTextboxRegularStyle()
        {
            var regularStyle = new TextboxPropertiesStyle()
            {
                BackColor = Color.Transparent
            };
            return regularStyle;
        }
    }
}
