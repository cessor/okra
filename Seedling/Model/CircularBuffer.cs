using System.Collections.Generic;

namespace Seedling.Model
{
    internal class CircularBuffer<T> : List<T>
    {
        public CircularBuffer(int capacity) : base(capacity)
        {
        }

        public new void Add(T item)
        {
            if (Count == Capacity) RemoveAt(0);
            base.Add(item);
        }
    }
}