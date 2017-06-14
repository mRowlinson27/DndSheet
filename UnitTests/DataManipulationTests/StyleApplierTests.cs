using System.Collections.Generic;
using DataManipulation;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class StyleApplierTests
    {
        private StyleApplier<Generic> _styleApplier;

        [SetUp]
        public void Setup()
        {
            _styleApplier = new StyleApplier<Generic>();
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

            var response = _styleApplier.Apply(new Generic(), data);

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

            var response = _styleApplier.Apply(new Generic(), data);

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

            var response = _styleApplier.Apply(new Generic(), data);

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

            var generic = new Generic();

            _styleApplier.Apply(generic, data);

            generic.Property.Should().Be(stringData);
        }
    }

    internal class Generic
    {
        public string Property { get; set; }
    }
}
