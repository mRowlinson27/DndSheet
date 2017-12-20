
namespace Utilities.UnitTests
{
    using System;
    using API;
    using API.DAL;
    using FakeItEasy;
    using Implementation;
    using Implementation.DAL;
    using NUnit.Framework;

    [TestFixture]
    public class LoggerTests
    {
        private Logger _logger;
        private IFileWriter _fileWriter;
        private IDateTimeWrapper _dateTimeWrapper;

        [SetUp]
        public void Setup()
        {
            _fileWriter = A.Fake<IFileWriter>();
            _dateTimeWrapper = A.Fake<IDateTimeWrapper>();
            _logger = new Logger(_fileWriter, _dateTimeWrapper);
        }

        [Test]
        public void LogMessage_LogsTimeCallingMethodAndMessage()
        {
            //Arrange
            var message = "message";
            var currentTime = new DateTime(2000, 1, 2, 3, 4, 5);
            A.CallTo(() => _dateTimeWrapper.GetCurrentDateTime()).Returns(currentTime);
            var correctMessage = "3:04:05 AM | LoggerTests::LogMessage_LogsTimeCallingMethodAndMessage:39 | message" + '\n';

            //Act
            _logger.LogMessage(message);

            Console.WriteLine(correctMessage);

            //Assert
            A.CallTo(() => _fileWriter.Write(A<string>.Ignored,
                    A<string>.That.Matches(x => String.CompareOrdinal(x, correctMessage) == 0)))
                .MustHaveHappened();
        }
    }
}
