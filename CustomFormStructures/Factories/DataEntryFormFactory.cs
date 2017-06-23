using CustomForms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.API.Factories;

namespace CustomFormStructures.Factories
{
    public class DataEntryFormFactory : IDataEntryFormFactory
    {
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;

        public DataEntryFormFactory(ITableLayoutWrapperFactory tableLayoutWrapperFactory)
        {
            _tableLayoutWrapperFactory = tableLayoutWrapperFactory;
        }

        public IDataEntryForm Create()
        {
            return new DataEntryForm(_tableLayoutWrapperFactory.Create());
        }
    }
}
