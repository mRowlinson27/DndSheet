using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutColumnStyleCollectionWrapper
    {
        void Add(ColumnStyle columnStyle);
        int Count { get; }
    }
}
