
namespace WpfUI.API
{
    using System.Threading.Tasks;
    using Utilities.API;

    public interface IMainWindow
    {
        ILogger Logger { get; set; }

        IDictionaryTableFactory DictionaryTableFactory { get; set; }

        void Initialize();
    }
}
