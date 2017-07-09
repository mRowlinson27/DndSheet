namespace DataManipulation.API.DataPoint
{
    public interface IDataPointClientFactory
    {
        IDataPointClient Create(IDataPoint dataPoint, object value);
    }
}
