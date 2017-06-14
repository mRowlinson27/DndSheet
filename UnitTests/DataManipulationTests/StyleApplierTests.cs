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
            
            Assert.That(() => _styleApplier.Apply(original, style),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Apply_PropertyDifferentType_Exception()
        {
            IGeneric original = new Generic1() { TypeCheck = "test"};
            IGeneric style = new Generic2() { TypeCheck = 2 };

            Assert.That(() => _styleApplier.Apply(original, style),
                Throws.TypeOf<ArgumentException>());
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
