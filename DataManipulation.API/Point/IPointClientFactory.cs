namespace DataManipulation.API.Point
{
    public interface IPointClientFactory
    {
        IPointClient Create(IPoint point, object value);
    }
}
