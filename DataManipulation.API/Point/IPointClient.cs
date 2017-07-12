namespace DataManipulation.API.Point
{
    public interface IPointClient
    {
        object Output { get; }
        void UnSubscribeTo(IPoint point);
        void SubscribeTo(IPoint point, object currentChange);
    }
}
