using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.DTO;
using DataManipulation.Interfaces;
using Utilities.API;

namespace DataManipulation
{
    public class PointUpdateSubscriber : IPointUpdateSubscriber
    {
        private readonly IPointUpdateStrategy _pointUpdateStrategy;

        public PointUpdateSubscriber(IPointUpdateStrategy pointUpdateStrategy)
        {
            _pointUpdateStrategy = pointUpdateStrategy;
        }

        public void SubscribeToPoint(IPoint point)
        {
            point.Updated += PointOnUpdated;
            _pointUpdateStrategy.UpdatePointOutputChain(point);
        }

        public void UnSubscribeToPoint(IPoint point)
        {
            point.Updated -= PointOnUpdated;
        }

        private void PointOnUpdated(object sender, EventArgs eventArgs)
        {
            var point = sender as IPoint;
            if (point != null)
            {
                _pointUpdateStrategy.UpdatePointOutputChain(point);
            }
        }
    }
}
