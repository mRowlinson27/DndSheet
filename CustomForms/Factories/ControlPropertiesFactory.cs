﻿using System;
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
        public IControlPropertiesStyle Create()
        {
            return new ControlPropertiesStyle();
        }

        public ITextBoxPropertiesStyle CreateTextboxInEditStyle()
        {
            var inEditStyle = new TextBoxPropertiesStyle()
            {
                BackColor = Color.White
            };

            return inEditStyle;
        }

        public ITextBoxPropertiesStyle CreateTextboxRegularStyle()
        {
            var regularStyle = new TextBoxPropertiesStyle()
            {
                BackColor = Color.Transparent
            };
            return regularStyle;
        }
    }
}
