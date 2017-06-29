using System;
using CustomFormManipulation;
using DataManipulation;
using DataManipulation.API;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class PropertyApplierTests
    {
        private PropertyApplier<IGeneric> _propertyApplier;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = new PropertyApplier<IGeneric>();
        }

        [Test]
        public void Apply_GenericObjectPrototyped()
        {
            var propertyValue = "test";
            var original = new Generic1();
            var style = new Generic1() { Property = propertyValue };

            _propertyApplier.Apply(original, style);

            original.Property.Should().Be(style.Property);
        }

        [Test]
        public void Apply_PropertyIsDefault_NoChange()
        {
            var propertyValue = "test";
            IGeneric original = new Generic1() { Property = propertyValue };
            var style = new Generic1();
            style.SetHasPropertyChanged(false);

            _propertyApplier.Apply(original, style);

            original.Property.Should().Be(propertyValue);
        }

        [Test]
        public void Apply_NoProperty_Exception()
        {
            IGeneric original = new Generic1();
            IGeneric style = new Generic2() { OneHasProperty = "test" };
            
            Assert.That(() => _propertyApplier.Apply(original, style),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Apply_PropertyDifferentType_Exception()
        {
            IGeneric original = new Generic1() { TypeCheck = "test"};
            IGeneric style = new Generic2() { TypeCheck = 2 };

            Assert.That(() => _propertyApplier.Apply(original, style),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Apply_BoolPropertySetToDefaultValue_OriginalBoolSet()
        {
            IGeneric original = new Generic1() { BoolVal = true };
            var style = new Generic1() {BoolVal = false};

            _propertyApplier.Apply(original, style);

            original.BoolVal.Should().Be(false);
        }
    }

    internal interface IGeneric : IPropertyChangedChecker
    {
        string Property { get; set; }
        bool BoolVal { get; set; }
    }

    internal class Generic1 : IGeneric
    {
        public string Property { get; set; }
        public string TypeCheck { get; set; }
        public bool BoolVal { get; set; }
        public bool HasPropertyChanged(string property)
        {
            return _changedProperty;
        }

        private bool _changedProperty = true;

        public void SetHasPropertyChanged(bool value)
        {
            _changedProperty = value;
        }
    }

    internal class Generic2 : IGeneric
    {
        public string Property { get; set; }
        public int TypeCheck { get; set; }
        public bool BoolVal { get; set; }
        public string OneHasProperty { get; set; }
        public bool HasPropertyChanged(string property)
        {
            return _changedProperty;
        }

        private bool _changedProperty = true;

        public void SetHasPropertyChanged(bool value)
        {
            _changedProperty = value;
        }
    }
}
