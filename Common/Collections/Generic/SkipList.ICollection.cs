namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed partial class SkipList<T> : ICollection<T> where T : IComparable<T>
    {
        public void Add(T item)
        {
            this.Insert(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this.Delete(item);
        }

        public void Clear()
        {
            this.InitParameters();
        }
    }
}
