using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    internal class GenericList<T> : IGenericList<T> /*where T : T2*/
    {
        private T[] _array;
        private const int MaxArrayLength = 10;
        private int position;

        public GenericList() : this(MaxArrayLength)
        {
        }
        public GenericList(int size)
        {
            _array = new T[size];
            position = 0;
        }

        public int Length => position;

        public void Add(T item)
        {
            if(position == _array.Length)
            {
                Expand();
            }
            _array[position] = item;
            position++;
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < position; i++)
            {
                if (_array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= position - 1)
                throw new IndexListOutsideRangeException(position,index,_array.Length);

            return _array[index];
        }

        public void Remove(T item)
        {
            int index = -1;
            for(int i = 0; i < position; i++)
                if (_array[i].Equals(item))
                {
                    index = i;
                    break;
                }
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= position - 1)
                throw new IndexListOutsideRangeException(position, index, _array.Length);

            T[] temp = new T[_array.Length];
            int i = 0;
            for(;i < index;i++)
                temp[i] = _array[i];
            for (; i < _array.Length - 1; i++)
                temp[i] = _array[i + 1];
            _array = temp;
            position--;
        }

        private void Expand()
        {
            T[] expandedArray = new T[_array.Length + 1];
            for(int i = 0; i < _array.Length; i++)
                expandedArray[i] = _array[i];
            _array = expandedArray;
        }

        public void GenericMethod<P>(P item) where P : struct
        {
            Console.WriteLine(item);
        }
    }
}
