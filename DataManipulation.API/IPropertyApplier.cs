namespace DataManipulation.API
{
    public interface IPropertyApplier<T>
    {
        T Apply<T2>(T input, T2 style) where T2 : IPropertyChangedChecker;
    }
}
