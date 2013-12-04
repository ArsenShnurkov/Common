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

        /// <summary>
        /// Looks for a node with a matching value in this tree. Returns null if not found
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value of the node to find</param>
        /// <returns>
        /// null if the node was not found
        /// or the node if it was found
        /// </returns>
        public bool Contains(T item)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            IterativeBinaryNode<T> current = this.Root;
            while (current != null)
            {
                int compareResult = current.Value.CompareTo(item);
                if (compareResult == 0)
                    break;
                else if (compareResult > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return current != null;
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
