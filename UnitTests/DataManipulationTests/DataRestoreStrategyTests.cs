using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using DataManipulation.API;
using DataManipulation.API.DataPoint;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase.API;
using SqlDatabase.API.DTO;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class DataRestoreStrategyTests
    {
        private DataRestoreStrategy _dataRestoreStrategy;
        private IDictionaryGraphNodeFactory<IDataPoint> _dictionaryGraphNodeFactory;
        private IDatabaseControl _databaseControl;
        private IDataPointBuilder _dataPointBuilder;
        private List<TableEntity> _tableEntities;
        private IDataPoint _dataPoint1;
        private IDataPoint _dataPoint2;

        [SetUp]
        public void Setup()
        {
            _dictionaryGraphNodeFactory = A.Fake<IDictionaryGraphNodeFactory<IDataPoint>>();
            _databaseControl = A.Fake<IDatabaseControl>();
            _dataPointBuilder = A.Fake<IDataPointBuilder>();
            _dataRestoreStrategy = new DataRestoreStrategy(_dataPointBuilder, _dictionaryGraphNodeFactory);
        }

        [Test]
        public void CreateAllPoints_GetsAllEntitiesAndBuildsThem()
        {
            SetupPointCreation();

            _dataRestoreStrategy.CreateAllPoints(_databaseControl);

            A.CallTo(() => _databaseControl.FindAllEntities()).MustHaveHappened();
            A.CallTo(() => _dataPointBuilder.BuildPoint(_tableEntities[0])).MustHaveHappened()
                .Then(A.CallTo(() => _dataPointBuilder.BuildPoint(_tableEntities[1])).MustHaveHappened());
        }

        [Test]
        public void CreateAllPoints_InsertsAllPredicatesAfterCreation()
        {
            SetupPointCreation();
            
            _dataRestoreStrategy.CreateAllPoints(_databaseControl);

            A.CallTo(() => _databaseControl.FindAllEntities()).MustHaveHappened();
            A.CallTo(() => _dataPointBuilder.BuildPoint(_tableEntities[0])).MustHaveHappened()
                .Then(A.CallTo(() => _dataPointBuilder.BuildPoint(_tableEntities[1])).MustHaveHappened())
                .Then(A.CallTo(() => _databaseControl.FindPredicatesAffectedBySubject(A<int>.Ignored))
                    .MustHaveHappened(Repeated.Exactly.Twice));
        }

        [Test]
        public void CreateAllPoints_InsertsPredicatesCorrectly()
        {
            SetupPointCreation();
            var tripleData = new List<Triple> {new Triple
            {
                Object = _tableEntities[0].Eid,
                Relationship = "test",
                Subject = _tableEntities[1].Eid
            }};
            A.CallTo(() => _databaseControl.FindPredicatesAffectedBySubject(_tableEntities[0].Eid)).Returns(tripleData);

            _dataRestoreStrategy.CreateAllPoints(_databaseControl);

            A.CallTo(() => _dataPoint1.AddSubscriber(_dataPoint2, tripleData[0].Relationship)).MustHaveHappened();
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

            A.CallTo(() => _databaseControl.FindEntitiesByDatatype("Head")).Returns(heads);

            _dataRestoreStrategy.RestoreTree(headName, _databaseControl);

        }

        private void SetupPointCreation()
        {
            _tableEntities = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                },
                new TableEntity
                {
                    Eid = 2, DataType = "Int", Value = "1"
                }
            };
            _dataPoint1 = A.Fake<IDataPoint>();
            _dataPoint2 = A.Fake<IDataPoint>();
            A.CallTo(() => _databaseControl.FindAllEntities()).Returns(_tableEntities);
            A.CallTo(() => _dataPointBuilder.BuildPoint(A<TableEntity>.Ignored))
                .ReturnsNextFromSequence(_dataPoint1, _dataPoint2);
            A.CallTo(() => _dataPoint1.Eid).Returns(_tableEntities[0].Eid);
            A.CallTo(() => _dataPoint2.Eid).Returns(_tableEntities[1].Eid);
        }
    }
}
