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
    public class PointUpdateStrategy : IPointUpdateStrategy
    {
        private readonly IDirectedGraph<IPoint, PointEquation> _underlyingDirectedGraph;
        private readonly IEquationCalculateStrategy _equationCalculateStrategy;

        public PointUpdateStrategy(IDirectedGraph<IPoint, PointEquation> underlyingDirectedGraph, IEquationCalculateStrategy equationCalculateStrategy)
        {
            _underlyingDirectedGraph = underlyingDirectedGraph;
            _equationCalculateStrategy = equationCalculateStrategy;
        }

        public void UpdatePointOutputChain(IPoint point)
        {
            UpdatePointOutputChainInternal(point, new List<int>());
        }

        private void UpdatePointOutputChainInternal(IPoint point, List<int> path)
        {
            if (path.Contains(point.Eid))
            {
                throw new CircularReferenceException();
            }
            path.Add(point.Eid);

            point.Output = point.Value;
            var parents = _underlyingDirectedGraph.GetParentRelationOf(point);
            if (parents.Any())
            {
                point.Output = _equationCalculateStrategy.CalculateEquation(point, parents);
            }

            foreach (var childRelation in _underlyingDirectedGraph.GetChildRelationOf(point))
            {
                UpdatePointOutputChainInternal(childRelation.Item1, path);
            }
        }
    }

    
}
