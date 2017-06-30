using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormStructures.API.Builders
{
    public interface ICentralLayoutBuilder
    {
        ITableLayoutWrapper Build(IControlPropertiesStyle tablePropertiesStyle = null);
    }
}