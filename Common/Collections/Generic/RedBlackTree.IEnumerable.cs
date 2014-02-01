namespace Common.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed partial class RedBlackTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return ((IBinarySearchTree<T>)this).InOrderIterator.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IBinarySearchTree<T>)this).InOrderIterator.GetEnumerator();
        }
    }
}
