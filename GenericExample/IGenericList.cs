using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    internal interface IGenericList<T>
    {
        void Add(T item);
        void RemoveAt(int index);
        void Remove(T item);
        T Get(int index);
        bool Contains(T item);
        int Length { get; }
    }
}
