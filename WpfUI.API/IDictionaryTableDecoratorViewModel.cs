
namespace WpfUI.API
{
    public interface IDictionaryTableDecoratorViewModel : IDictionaryTableViewModel
    {
        void AllowEditing();
        void DisallowEditing();
    }
}
