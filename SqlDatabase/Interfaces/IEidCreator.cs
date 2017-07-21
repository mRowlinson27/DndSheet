using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.Interfaces
{
    public interface IEidCreator
    {
        int GetNextEid();
        List<int> GetNextXEids(int x);
    }
}
