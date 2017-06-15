namespace DataManipulation.API
{
    public interface IPropertyApplier<T>
    {
        T Apply(T input, T style);
    }
}
