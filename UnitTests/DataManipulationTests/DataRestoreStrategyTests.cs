﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using DataManipulation.API;
using DataManipulation.DTO;
using DataManipulation.Interfaces;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase.API;
using SqlDatabase.API.DTO;
using Utilities.API;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class DataRestoreStrategyTests
    {
        private DataRestoreStrategy _dataRestoreStrategy;
        private IDictionaryGraphNodeFactory<IPoint> _dictionaryGraphNodeFactory;
        private IDatabase _database;
        private IPointBuilder _pointBuilder;
        private List<TableEntity> _tableEntities;
        private IPoint _point1;
        private IPoint _point2;

        [SetUp]
        public void Setup()
        {
            _dictionaryGraphNodeFactory = A.Fake<IDictionaryGraphNodeFactory<IPoint>>();
            _database = A.Fake<IDatabase>();
            _pointBuilder = A.Fake<IPointBuilder>();
            _dataRestoreStrategy = new DataRestoreStrategy(_pointBuilder, _dictionaryGraphNodeFactory);
        }

        [Test]
        public void CreateAllPoints_GetsAllEntitiesAndBuildsThem()
        {
           Assert.That(true==false);
        }

        [Test]
        public void RestoreTree_GetsHeadCorrectly()
        {
            var headName = "Page1";
            var otherHead = "";
            var heads = new List<TableEntity>
            {
                new TableEntity()
                {
                    Eid = 0,
                    DataType = "Head",
                    Value = headName
                },
                new TableEntity()
                {
                    Eid = 1,
                    DataType = "Head",
                    Value = otherHead
                }
            };

            A.CallTo(() => _database.FindEntitiesByDatatype("Head")).Returns(heads);

            _dataRestoreStrategy.RestoreTree(headName, _database);

        }
    }
}
