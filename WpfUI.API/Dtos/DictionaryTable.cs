
namespace WpfUI.API.Dtos
{
    using System.Collections.Generic;

    public class DictionaryTable
    {
        public List<ColumnHeadings> Headings { get; set; } 

        public List<Dictionary<string, object>> Rows { get; set; }
    }
}
