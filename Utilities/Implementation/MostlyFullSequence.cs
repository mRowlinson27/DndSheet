using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.API;

namespace Utilities.Implementation
{
    public class MostlyFullSequence : IMostlyFullSequence
    {
        private List<int> _ints;

        public MostlyFullSequence()
        {
            _ints = new List<int> {0, 0};
        }

        public List<int> GetInternaList()
        {
            return _ints;
        }

        public int Add()
        {
            var index = _ints[1] + 1;
            Insert(index);
            return index;
        }

        public List<int> AddMultiple(int amount)
        {
            var addedIndexes = new List<int>();
            for (var i = 0; i < amount; i++)
            {
                addedIndexes.Add(Add());
            }
            return addedIndexes;
        }

        public void Insert(int index)
        {
            if (ContainsIndex(index))
            {
                throw new InvalidOperationException();
            }

            if (IndexIsLargerThenCurrentMaxByMoreThanOne(index))
            {
                _ints.Add(index);
                _ints.Add(index);
                return;
            }

            if (IndexIsLargerThenCurrentMaxByOne(index))
            {
                _ints[_ints.Count - 1] = index;
                return;
            }

            for (var i = 1; i < _ints.Count; i++)
            {
                if (IndexIsInBetweenValuesByMoreThanOne(i - 1, i, index))
                {
                    _ints.Insert(i, index);
                    _ints.Insert(i, index);
                    return;
                }
                if (IndexIsInBetweenBothValuesByOne(i - 1, i, index))
                {
                    _ints.RemoveAt(i);
                    _ints.RemoveAt(i - 1);
                    return;
                }
                if (IndexIsOneMoreThanLowerBoundAndMoreThanOneBelowUpperBound(i - 1, i, index))
                {
                    _ints[i - 1] = index;
                    return;
                }
                if (IndexIsSmallerByOne(i, index))
                {
                    _ints[i] = index;
                    return;
                }
            }
        }

        public void InsertMultiple(List<int> indexes)
        {
            foreach (var i in indexes)
            {
                Insert(i);
            }
        }

        public void DeleteAt(int index)
        {
            if (!ContainsIndex(index) || index == 0)
            {
                throw new InvalidOperationException();
            }

            for (var i = 1; i < _ints.Count; i+=2)
            {
                if (IndexIsEqualToBothValues(i - 1, i, index))
                {
                    _ints.RemoveAt(i);
                    _ints.RemoveAt(i - 1);
                    return;
                }

                if (_ints[i - 1] == index)
                {
                    _ints[i - 1] += 1;
                    return;
                }

                if (_ints[i] == index)
                {
                    _ints[i] -= 1;
                    return;
                }

                if (index < _ints[i]  && _ints[i - 1] < index)
                {
                    _ints.Insert(i, index + 1);
                    _ints.Insert(i, index - 1);
                    return;
                }
            }
        }

        public void DeleteMultipleAt(List<int> indexes)
        {
            foreach (var i in indexes)
            {
                DeleteAt(i);
            }
        }

        public void Clear()
        {
            _ints = new List<int> { 0, 0 };
        }

        private bool ContainsIndex(int index)
        {
            for (int i = 1; i < _ints.Count; i += 2)
            {
                if (_ints[i] >= index && index >= _ints[i - 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IndexIsLargerThenCurrentMaxByMoreThanOne(int index)
        {
            return _ints.Last() < index - 1;
        }

        private bool IndexIsLargerThenCurrentMaxByOne(int index)
        {
            return _ints.Last() == index - 1;
        }

        private bool IndexIsInBetweenValuesByMoreThanOne(int v1, int v2, int index)
        {
            return index > _ints[v1] + 1 && _ints[v2] > index + 1;
        }

        private bool IndexIsInBetweenBothValuesByOne(int v1, int v2, int index)
        {
            return index == _ints[v1] + 1 && _ints[v2] == index + 1;
        }

        private bool IndexIsOneMoreThanLowerBoundAndMoreThanOneBelowUpperBound(int v1, int v2, int index)
        {
            return index == _ints[v1] + 1 && _ints[v2] > index + 1;
        }

        private bool IndexIsSmallerByOne(int v1, int index)
        {
            return _ints[v1] == index + 1;
        }

        private bool IndexIsEqualToBothValues(int v1, int v2, int index)
        {
            return _ints[v1] == index && _ints[v2] == index;
        }
    }
}
