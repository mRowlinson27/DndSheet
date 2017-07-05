namespace SqlDatabase.Interfaces
{
    public interface ISqLiteConnectionWrapperFactory
    {
        ISqLiteConnectionWrapper Create(string connection);
    }
}
