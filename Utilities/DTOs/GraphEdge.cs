using Utilities.Implementation;

namespace Utilities.DTOs
{
    public class GraphEdge<TNode, TEdge>
    {
        public GraphNode<TNode, TEdge> OtherNode;
        public TEdge EdgeValue;
    }
}
