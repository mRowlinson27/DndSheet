using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.DTOs;

namespace CustomForms.API
{
    public interface IStyleApplier<T>
    {
        T Apply(T input, Dictionary<string, object> dictionary);
    }
}
