using System.Collections.Generic;

namespace Utilities.DTOs
{
    public class GraphNode<TNode, TEdge>
    {
        public TNode Value { get; set; }
        public List<GraphEdge<TNode, TEdge>> ParentEdges { get; set; }
        public List<GraphEdge<TNode, TEdge>> ChildEdges { get; set; }

        public GraphNode(TNode data)
        {
            Value = data;
            ParentEdges = new List<GraphEdge<TNode, TEdge>>();
            ChildEdges = new List<GraphEdge<TNode, TEdge>>();
        }
    }
}
