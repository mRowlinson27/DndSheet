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
    public class TextBoxPropertiesStyleTests
    {
        private TextBoxPropertiesStyle _textBoxPropertiesStyle;

        [SetUp]
        public void Setup()
        {
            _textBoxPropertiesStyle = new TextBoxPropertiesStyle();
        }

        [Test]
        public void HasPropertyChanged_PropertySetPreviously_ReturnsTrue()
        {
            _textBoxPropertiesStyle.ReadOnly = true;

            _textBoxPropertiesStyle.HasPropertyChanged("ReadOnly").Should().BeTrue();
        }

        [Test]
        public void HasPropertyChanged_PropertySetPreviouslyToDefault_ReturnsTrue()
        {
            _textBoxPropertiesStyle.ReadOnly = false;

            _textBoxPropertiesStyle.HasPropertyChanged("ReadOnly").Should().BeTrue();
        }

        [Test]
        public void HasPropertyChanged_PropertyNotSetPreviously_ReturnsFalse()
        {
            _textBoxPropertiesStyle.HasPropertyChanged("ReadOnly").Should().BeFalse();
        }
    }
}
