
namespace Utilities.Implementation
{
    using System;
    using System.Collections.Generic;
    using API;

    public class DictionaryGraphNode<T> : IDictionaryGraphNode<T>
    {
        private readonly T _data;
        private Dictionary<int, IDictionaryGraphNode<T>> _dictionary = new Dictionary<int, IDictionaryGraphNode<T>>();
        public int Eid { get; }
        public IDictionaryGraphNode<T> Parent { get; set; }

        public DictionaryGraphNode(int eid, T data)
        {
            Eid = eid;
            _data = data;
        }

        public void Add(IDictionaryGraphNode<T> item)
        {
            if (ContainsKey(item.Eid))
            {
                throw new InvalidOperationException("Cannot add itself");
            }
            item.Parent = this;
            _dictionary.Add(item.Eid, item);
        }

        public IDictionaryGraphNode<T> GetNode(int eid)
        {
            if (eid == Eid)
            {
                return this;
            }
            foreach (var node in _dictionary.Values)
            {
                var val = node.GetNode(eid);
                if (val != null)
                {
                    return val;
                }
            }
            return null;
        }

        public T Get(int eid)
        {
            if (eid == Eid)
            {
                return _data;
            }
            foreach (var node in _dictionary.Values)
            {
                var val = node.Get(eid);
                if (val != null)
                {
                    return val;
                }
            }
            return default(T);
        }

        public void Clear()
        {
            foreach (var node in _dictionary.Values)
            {
                node.Clear();
            }
            _dictionary = new Dictionary<int, IDictionaryGraphNode<T>>();
        }

        public bool Contains(IDictionaryGraphNode<T> node)
        {
            return ContainsKey(node.Eid);
        }

        public bool ContainsKey(int eid)
        {
            if (Eid == eid)
            {
                return true;
            }

            if (_dictionary.ContainsKey(eid))
            {
                return true;
            }

            foreach (var node in _dictionary.Values)
            {
                if (node.ContainsKey(eid))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int eid)
        {
            if (_dictionary.ContainsKey(eid))
            {
                _dictionary[eid].Parent = null;
                _dictionary.Remove(eid);
                return true;
            }
            foreach (var node in _dictionary.Values)
            {
                if (node.Remove(eid))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(IDictionaryGraphNode<T> item)
        {
            return Remove(item.Eid);
        }
    }
}
