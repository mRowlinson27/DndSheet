
namespace Utilities.Implementation
{
    using API;
    using API.DAL;

    public class Logger : ILogger
    {
        private readonly IFileWriter _fileWriter;
        private readonly IDateTimeWrapper _dateTimeWrapper;
        private string logFilePath = "C:\\Temp\\CharacterLog.txt";

        public Logger(IFileWriter fileWriter, IDateTimeWrapper dateTimeWrapper)
        {
            _fileWriter = fileWriter;
            _dateTimeWrapper = dateTimeWrapper;
        }

        public void LogMessage(string message, 
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            var time = _dateTimeWrapper.GetCurrentDateTime();
            var classFileName = sourceFilePath.Substring(sourceFilePath.LastIndexOf('\\') + 1);
            var className = classFileName.Substring(0, classFileName.Length - 3);

            var finalLog = time.ToLongTimeString() + " | " + className + "::" + memberName + ":" + sourceLineNumber +
                           " | " + message + '\n';

            _fileWriter.Write(logFilePath, finalLog);
        }
    }
}
