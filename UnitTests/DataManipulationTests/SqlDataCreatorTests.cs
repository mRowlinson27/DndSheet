using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using DataManipulation.API.DTOs;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class SqlDataCreatorTests
    {
        private SqlDataCreator _sqlDataCreator;

        [SetUp]
        public void Setup()
        {
            _sqlDataCreator = new SqlDataCreator();
        }

        [Test]
        public void ConvertAbilityScore_ReturnsCorrectSqlData()
        {
//            var strengthScore = new AbilityScore
//            {
//                Name = "Strength",
//                Abr = "Str",
//                Value = 14
//            };

            var sqlData = _sqlDataCreator.Create(null);
        }
    }
}
