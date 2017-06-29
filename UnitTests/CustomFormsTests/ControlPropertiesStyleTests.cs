using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.DTOs;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests
{
    [TestFixture]
    public class ControlPropertiesStyleTests
    {
        private ControlPropertiesStyle _controlPropertiesStyle;

        [SetUp]
        public void Setup()
        {
            _controlPropertiesStyle = new ControlPropertiesStyle();
        }

        [Test]
        public void HasPropertyChanged_PropertySetPreviously_ReturnsTrue()
        {
            _controlPropertiesStyle.Enabled = true;

            _controlPropertiesStyle.HasPropertyChanged("Enabled").Should().BeTrue();
        }

        [Test]
        public void HasPropertyChanged_PropertySetPreviouslyToDefault_ReturnsTrue()
        {
            _controlPropertiesStyle.Enabled = false;

            _controlPropertiesStyle.HasPropertyChanged("Enabled").Should().BeTrue();
        }

        [Test]
        public void HasPropertyChanged_PropertyNotSetPreviously_ReturnsFalse()
        {
            _controlPropertiesStyle.HasPropertyChanged("Enabled").Should().BeFalse();
        }
    }
}
