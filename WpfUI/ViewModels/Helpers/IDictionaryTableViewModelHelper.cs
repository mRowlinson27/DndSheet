
namespace WpfUI.ViewModels.Helpers
{
    using System.Data;
    using System.Threading.Tasks;
    using API.Dtos;

    public interface IDictionaryTableViewModelHelper
    {
        DataTable ConvertDictionaryTableToDataTable(DictionaryTable dictionaryTable);
        DictionaryTable ConvertDataTableToDictionaryTable(DataTable dataTable);
    }
}
