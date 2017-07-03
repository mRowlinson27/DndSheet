using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDatabase
    {
        private readonly ISqLiteWrapperFactory _sqLiteWrapperFactory;
        private ISqLiteWrapper _sqLiteWrapper;

        public SqLiteDatabase(ISqLiteWrapperFactory sqLiteWrapperFactory)
        {
            _sqLiteWrapperFactory = sqLiteWrapperFactory;
        }

        public void Connect(string connection)
        {
            _sqLiteWrapper = _sqLiteWrapperFactory.Create();
            _sqLiteWrapper.Connect(connection);
        }
    }
}
