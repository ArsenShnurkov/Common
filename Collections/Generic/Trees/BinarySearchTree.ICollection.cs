namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public partial class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
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
            IBinaryNode<T> deletedItem = null;

            try
            {
                deletedItem = this.Delete(item);
            }
            catch (NodeNotFoundException)
            {
            }

            return deletedItem != null;
        }


        public void Clear()
        {
            this.Clear();
        }
    }
}
