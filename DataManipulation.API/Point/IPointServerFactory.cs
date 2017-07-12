namespace DataManipulation.API.Point
{
    public interface IPointServerFactory
    {
        IPointServer Create(IPoint point, IPointCalculateStrategy pointCalculateStrategy);
    }
}
