namespace DataManipulation.API.DataPoint
{
    public interface IDataPointServerFactory
    {
        IDataPointServer Create(IDataPoint dataPoint, IDataPointCalculateStrategy dataPointCalculateStrategy);
    }
}
