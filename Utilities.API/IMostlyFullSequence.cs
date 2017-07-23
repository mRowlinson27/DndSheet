using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.API
{
    public interface IMostlyFullSequence
    {
        int Add();
        List<int> AddMultiple(int amount);
        void Insert(int index);
        void InsertMultiple(List<int> indexes);
        void DeleteAt(int index);
        void DeleteMultipleAt(List<int> indexes);
    }
}
