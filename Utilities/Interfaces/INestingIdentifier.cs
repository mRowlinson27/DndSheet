using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DTOs;

namespace Utilities.Interfaces
{
    public interface INestingIdentifier
    {
        StringRange FindDeepestNest(string equation);
    }
}
