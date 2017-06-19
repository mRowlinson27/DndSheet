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
            var regularStyle = new ControlStyle(
                new ControlPropertiesStyle()
                {
                    BackColor = Color.Transparent
                },
                new ControlEventsStyle()
                {

                });
//            regularStyle.ControlEvents.Enter += OnEnter;
//            regularStyle.ControlEvents.TextChanged += OnTextChanged;
            return regularStyle.ControlProperties;
        }

        protected void OnEnter(object sender, System.EventArgs e)
        {
            var control = sender as Control;
            if (control != null) control.Parent.Parent.Focus();
        }

        protected void OnTextChanged(object sender, System.EventArgs e)
        {
            var control = sender as IControl;
            if (control != null)
            {
                Size size = TextRenderer.MeasureText(control.Text, control.Font);
                control.Width = (int)Math.Ceiling(((float)size.Width) + 10);
            }
        }
    }
}
