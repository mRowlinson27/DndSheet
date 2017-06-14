using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.Factories;
using CustomForms.API.TableLayoutWrapper;
using CustomForms.TableLayoutWrapperFields;

namespace CustomForms.Factories
{
    public class TableLayoutWrapperFactory : ITableLayoutWrapperFactory
    {
        public ITableLayoutWrapper Create()
        {
            return new TableLayoutWrapper();
        }
    }
}
