namespace Utilities.API
{
    public interface IDictionaryGraphNodeFactory<T>
    {
        IDictionaryGraphNode<T> Create(int eid, T data);
    }
}
