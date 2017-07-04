using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SqlDatabase;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class DatabaseControlTests
    {
        private DatabaseControl _databaseControl;

        [SetUp]
        public void Setup()
        {
            _databaseControl = new DatabaseControl();
        }

        [Test]
        public void Initialize_CreatesDatabase()
        {
            _databaseControl.Initialize("default.db");
        }
    }
}
