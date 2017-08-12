using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.DTO;

namespace DataManipulation.Interfaces
{
    public interface IPointUpdateStrategy
    {
        void UpdatePointOutputChain(IPoint point);
    }

    public class CircularReferenceException : Exception { }
}
