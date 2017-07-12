namespace DataManipulation.API.Point
{
    public interface IPointComponentsBuilder
    {
        IPointClient CreateClient(IPoint point);
        IPointServer CreateServer(IPoint point);
    }
}
