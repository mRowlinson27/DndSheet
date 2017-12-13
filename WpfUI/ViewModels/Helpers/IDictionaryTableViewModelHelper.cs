using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.ViewModels.Helpers
{
    using System.Data;

    public interface IDictionaryTableViewModelHelper
    {
        DataTable GetSource();
    }
}
