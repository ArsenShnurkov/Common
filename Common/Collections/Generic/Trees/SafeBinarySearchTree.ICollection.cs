namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public partial class SafeBinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        public void Add(T item)
        {
            this.Insert(item);
        }

        public bool Contains(T item)
        {
            return (this.FindOrDefault(item) != null);
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
            bool results = true;
            try
            {
                this.Delete(item);
            }
            catch (NodeNotFoundException)
            {
                results = false;
            }

            return results;
        }


        public void Clear()
        {
            this.Clear();
        }
    }
}
