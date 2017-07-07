using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API
{
    public interface IEidCreator
    {
        int GetNewEid();
        List<int> GetNewEids(int num);
    }
}
