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

        public IControlProperties CreateInEditStyle()
        {
            var inEditStyle = new ControlPropertiesStyle()
            {
                BackColor = Color.White
            };

            return inEditStyle;
        }

        public IControlProperties CreateRegularStyle()
        {
            var regularStyle = new ControlPropertiesStyle()
            {
                BackColor = Color.Transparent
            };
            return regularStyle;
        }
    }
}
