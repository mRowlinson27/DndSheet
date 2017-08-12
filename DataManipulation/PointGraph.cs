using System;
using System.Collections.Generic;
using System.Linq;
using DataManipulation.DTO;
using DataManipulation.Interfaces;
using Utilities.API;

namespace DataManipulation
{
    public class PointGraph
    {
        private readonly IDirectedGraph<IPoint, PointEquation> _graph;
        private readonly IPointUpdateSubscriber _pointSubscriber;
        private readonly Dictionary<int, object> _uniqueEidConstrainer;

        public PointGraph(IDirectedGraph<IPoint, PointEquation> graph, IPointUpdateSubscriber pointSubscriber)
        {
            _graph = graph;
            _pointSubscriber = pointSubscriber;
            _uniqueEidConstrainer = new Dictionary<int, object>();
        }

        public void AddPoint(IPoint point)
        {
            _uniqueEidConstrainer.Add(point.Eid, point);
            _graph.Add(point);
            _pointSubscriber.SubscribeToPoint(point);
        }

        public IPoint GetPoint(int eid)
        {
            if (_uniqueEidConstrainer.ContainsKey(eid))
            {
                return _uniqueEidConstrainer[eid] as IPoint;
            }
            return null;
        }

        public void DeletePoint(IPoint point)
        {
            _uniqueEidConstrainer.Remove(point.Eid);
            _graph.Remove(point);
            _pointSubscriber.UnSubscribeToPoint(point);
        }

        public void AddEquation(PointEquation equation)
        {
            _uniqueEidConstrainer.Add(equation.Eid, equation);
        }

        public void DeleteEquation(PointEquation equation)
        {
            _uniqueEidConstrainer.Remove(equation.Eid);
        }

        public PointEquation GetEquation(int eid)
        {
            if (_uniqueEidConstrainer.ContainsKey(eid))
            {
                return _uniqueEidConstrainer[eid] as PointEquation;
            }
            return null;
        }

        public PointEquation GetEquationByValue(string equationValue)
        {
            foreach (var equation in _uniqueEidConstrainer.Values.OfType<PointEquation>())
            {
                if (equation.Value == equationValue)
                {
                    return equation;
                }
            }
            return null;
        }

        public void AddEquationRelationship(IPoint from, IPoint to, PointEquation equation)
        {
            if (!(_uniqueEidConstrainer[from.Eid] is IPoint) || !(_uniqueEidConstrainer[to.Eid] is IPoint) || !(_uniqueEidConstrainer[equation.Eid] is PointEquation))
            {
                throw new KeyNotFoundException();
            }
            _graph.AddDirectedEdge(from, to, equation);
            to.Update();
        }

        public void DeleteEquationRelationship(IPoint from, IPoint to, PointEquation equation)
        {
            _graph.RemoveDirectedEdge(from, to, equation);
        }
    }
}
