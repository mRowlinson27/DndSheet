namespace CustomFormManipulation.API
{
    public interface IControlStyleApplier<T>
    {
        T Apply(T input, T style);
    }
}
