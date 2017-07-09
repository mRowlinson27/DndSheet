namespace DataManipulation.API.DataPoint
{
    public interface IDataPointComponentsBuilder
    {
        IDataPointClient CreateClient(IDataPoint dataPoint);
        IDataPointServer CreateServer(IDataPoint dataPoint);
    }
}
