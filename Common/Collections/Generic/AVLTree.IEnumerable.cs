namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public sealed partial class AVLTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return ((IBinarySearchTree<T>)this).InOrderIterator.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IBinarySearchTree<T>)this).InOrderIterator.GetEnumerator();
        }
    }
}
