namespace DataManipulation.API.DataPoint
{
    public interface IDataPointClient
    {
        object Output { get; }
        void UnSubscribeTo(IDataPoint dataPoint);
        void SubscribeTo(IDataPoint dataPoint, object currentChange);
    }
}
