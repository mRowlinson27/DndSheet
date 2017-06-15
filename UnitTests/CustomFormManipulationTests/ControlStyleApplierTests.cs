using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation;
using DataManipulation.API;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormManipulationTests
{
    [TestFixture]
    class ControlStyleApplierTests
    {
        private ControlStyleApplier<IGeneric> _controlStyleApplier;
        private IPropertyApplier<IGeneric> _propertyApplier;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = A.Fake<IPropertyApplier<IGeneric>>();
            _controlStyleApplier = new ControlStyleApplier<IGeneric>(_propertyApplier);
        }

        [Test]
        public void Apply_PropertiesApplied()
        {
            var generic = new Generic1();
            var genericStyle = new Generic1() {Property = "test"};

            _controlStyleApplier.Apply(generic, genericStyle);

            A.CallTo(() => _propertyApplier.Apply(generic, genericStyle)).MustHaveHappened();
        }

    }

    public interface IGeneric
    {
        string Property { get; set; }
    }

    internal class Generic1 : IGeneric
    {
        public string Property { get; set; }
    }
}
