using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;

namespace CustomForms.Builders
{
    public class DataEntryFormFactory : IDataEntryFormFactory
    {
        public IDataEntryForm Create()
        {
            return new DataEntryForm();
        }
    }
}
