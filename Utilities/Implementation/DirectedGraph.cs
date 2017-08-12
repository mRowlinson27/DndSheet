using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.API;
using Utilities.DTOs;

namespace Utilities.Implementation
{
    public class DirectedGraph<TNode, TEdge> : IDirectedGraph<TNode, TEdge>
    {
        private Dictionary<TNode, GraphNode<TNode, TEdge>> _nodeSet;

        public DirectedGraph()
        {
            _nodeSet = new Dictionary<TNode, GraphNode<TNode, TEdge>>();
        }

        public void Add(TNode value)
        {
            _nodeSet.Add(value, new GraphNode<TNode, TEdge>(value));
        }

        public void Remove(TNode value)
        {
            var nodeToRemove = _nodeSet[value];

            var childEdges = nodeToRemove.ChildEdges;
            foreach (var childEdge in childEdges)
            {
                var childsParentEdges = childEdge.OtherNode.ParentEdges;
                childsParentEdges.Remove(GetMatchingItemInEdges(value, childsParentEdges));
            }

            var parentEdges = nodeToRemove.ParentEdges;
            foreach (var parentEdge in parentEdges)
            {
                var parentsChildEdges = parentEdge.OtherNode.ChildEdges;
                parentsChildEdges.Remove(GetMatchingItemInEdges(value, parentsChildEdges));
            }

            _nodeSet.Remove(value);
        }

        public void AddDirectedEdge(TNode from, TNode to, TEdge cost)
        {
            var fromNode = _nodeSet[from];
            var toNode = _nodeSet[to];
            foreach (var edge in fromNode.ChildEdges)
            {
                if (edge.OtherNode == toNode && edge.EdgeValue.Equals(cost))
                {
                    throw new ArgumentException();
                }
            }
            fromNode.ChildEdges.Add(new GraphEdge<TNode, TEdge>() {EdgeValue = cost, OtherNode = toNode});
            toNode.ParentEdges.Add(new GraphEdge<TNode, TEdge>() { EdgeValue = cost, OtherNode = fromNode });
        }

        public void RemoveDirectedEdge(TNode from, TNode to, TEdge cost)
        {
            var fromNode = _nodeSet[from];
            var toNode = _nodeSet[to];
            var removedNum = 0;
            foreach (var edge in fromNode.ChildEdges)
            {
                if (edge.OtherNode == toNode && edge.EdgeValue.Equals(cost))
                {
                    fromNode.ChildEdges.Remove(edge);
                    removedNum++;
                    break;
                }
            }
            foreach (var edge in toNode.ParentEdges)
            {
                if (edge.OtherNode == fromNode && edge.EdgeValue.Equals(cost))
                {
                    toNode.ParentEdges.Remove(edge);
                    removedNum++;
                    break;
                }
            }
            if (removedNum != 2)
            {
                throw new KeyNotFoundException();
            }
        }

        public void Clear()
        {
            
            var nodeVals = _nodeSet.Select(node => node.Key).ToList();
            var i = nodeVals.Count - 1;
            while (i >= 0)
            {
                Remove(nodeVals[i]);
                i--;
            }
        }

        public bool Contains(TNode value)
        {
            return _nodeSet.ContainsKey(value);
        }

        private GraphEdge<TNode, TEdge> GetMatchingItemInEdges(TNode value, List<GraphEdge<TNode, TEdge>> edges)
        { 
            return edges.FirstOrDefault(edge => edge.OtherNode.Value.Equals(value));
        }

        public List<Tuple<TNode, TEdge>> GetParentRelationOf(TNode value)
        {
            return _nodeSet[value].ParentEdges.Select(x => new Tuple<TNode, TEdge>(x.OtherNode.Value, x.EdgeValue))
                .ToList();
        }

        public List<Tuple<TNode, TEdge>> GetChildRelationOf(TNode value)
        {
            return _nodeSet[value].ChildEdges.Select(x => new Tuple<TNode, TEdge>(x.OtherNode.Value, x.EdgeValue))
                .ToList();
        }

        public int Count
        {
            get { return _nodeSet.Count; }
        }
    }
}
