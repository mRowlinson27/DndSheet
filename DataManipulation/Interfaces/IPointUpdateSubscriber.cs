using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.DTO;

namespace DataManipulation.Interfaces
{
    public interface IPointUpdateSubscriber
    {
        void SubscribeToPoint(IPoint point);
        void UnSubscribeToPoint(IPoint point);
    }
}
