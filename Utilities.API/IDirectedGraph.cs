using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.API
{
    public interface IDirectedGraph <TNode, TEdge>
    {
        void Add(TNode value);
        void Remove(TNode value);
        void AddDirectedEdge(TNode from, TNode to, TEdge cost);
        void RemoveDirectedEdge(TNode from, TNode to, TEdge cost);
        void Clear();
        bool Contains(TNode value);
        List<Tuple<TNode, TEdge>> GetParentRelationOf(TNode value);
        List<Tuple<TNode, TEdge>> GetChildRelationOf(TNode value);
        int Count { get; }
    }
}
