using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API
{
    public interface IDictionaryGraphNode<T>
    {
        int Eid { get; }
        IDictionaryGraphNode<T> Parent { get; set; }

        void Add(IDictionaryGraphNode<T> item);

        T Get(int eid);
        IDictionaryGraphNode<T> GetNode(int eid);

        void Clear();

        bool Contains(IDictionaryGraphNode<T> node);

        bool ContainsKey(int eid);

        bool Remove(int eid);

        bool Remove(IDictionaryGraphNode<T> item);
    }
}
