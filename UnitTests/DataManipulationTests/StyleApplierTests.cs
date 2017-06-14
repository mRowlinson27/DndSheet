using System;
using System.Collections.Generic;
using DataManipulation;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class StyleApplierTests
    {
        private StyleApplier<IGeneric> _styleApplier;

        [SetUp]
        public void Setup()
        {
            _styleApplier = new StyleApplier<IGeneric>();
        }

        [Test]
        public void Apply_GenericObjectPrototyped()
        {
            var propertyValue = "test";
            var original = new Generic1();
            var style = new Generic1() { Property = propertyValue };

            _styleApplier.Apply(original, style);

            original.Property.Should().Be(style.Property);
        }

        [Test]
        public void Apply_PropertyIsDefault_NoChange()
        {
            var propertyValue = "test";
            IGeneric original = new Generic1() { Property = propertyValue };
            IGeneric style = new Generic1();

            _styleApplier.Apply(original, style);

            original.Property.Should().Be(propertyValue);
        }

        [Test]
        public void Apply_NoProperty_Exception()
        {
            IGeneric original = new Generic1();
            IGeneric style = new Generic2() { OneHasProperty = "test" };
            
            _styleApplier.Apply(original, style);

            Assert.That(() => _styleApplier.Apply(original, style),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GenericObject_SinglePropertySet()
        {
            var propertyName = "Property";
            var stringData = "test";

            var data = new Dictionary<string, object>
            {
                { propertyName, stringData}
            };

            var response = _styleApplier.Apply(new Generic1(), data);

            response.Property.Should().Be(stringData);
        }

        [Test]
        public void GenericObject_NoProperty_ReturnsNull()
        {
            var propertyName = "NoProperty";
            var stringData = "test";
            

            var data = new Dictionary<string, object>
            {
                { propertyName, stringData}
            };

            var response = _styleApplier.Apply(new Generic1(), data);

            response.Should().Be(null);
        }

        [Test]
        public void GenericObject_PropertyWrongType_ReturnsNull()
        {
            var propertyName = "NoProperty";
            var intData = 5;
            
            var data = new Dictionary<string, object>
            {
                { propertyName, intData}
            };

            var response = _styleApplier.Apply(new Generic1(), data);

            response.Should().Be(null);
        }

        [Test]
        public void GenericObject_OriginalObjectChanged()
        {
            var propertyName = "Property";
            var stringData = "test";

            var data = new Dictionary<string, object>
            {
                { propertyName, stringData}
            };

            var generic = new Generic1();

            _styleApplier.Apply(generic, data);

            generic.Property.Should().Be(stringData);
        }
    }

    internal interface IGeneric
    {
        string Property { get; set; }
    }

    internal class Generic1 : IGeneric
    {
        public string Property { get; set; }
        public string TypeCheck { get; set; }
    }

    internal class Generic2 : IGeneric
    {
        public string Property { get; set; }
        public int TypeCheck { get; set; }
        public string OneHasProperty { get; set; }
    }
}
