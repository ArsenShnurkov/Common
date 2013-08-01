namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public partial class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        #region Properties

        internal IInternalBinaryNode<T> Root { get; set; }

        /// <summary>
        /// Returns the number of nodes in the tree
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// The height of the tree. Returns -1 for an empty tree.
        /// </summary>
        public int Height
        {
            get
            {
                if (this.Root == null)
                    return -1;
                else
                    return this.Root.Height;
            }
        }

        /// <summary>
        /// Returns the balance of the tree defined as Balance = LeftTree.Height - Right.Height
        /// </summary>
        public int Balance
        {
            get
            {
                if (this.Root == null)
                    return 0;
                else
                    return this.Root.Balance;
            }
        }

        #endregion

        #region Find

        /// <summary>
        /// Searches for the value in the tree and returns an instance of IBinaryNode if found and returns null otherwise
        /// </summary>
        /// <param name="value">The value of the node to find in the tree</param>
        /// <returns>The node that was found or null otherwise</returns>
        public IBinaryNode<T> FindOrDefault(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            return FindOrDefault(this.Root, value);
        }

        /// <summary>
        /// Searches for the value in the tree and returns an instance of IBinaryNode if found and throws a NodeNotFoundException otherwise
        /// </summary>
        /// <param name="value">The value of the node to find in the tree</param>
        /// <returns>The node that was found</returns>
        public IBinaryNode<T> Find(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            IInternalBinaryNode<T> result = FindOrDefault(this.Root, value);

            if (result == null)
                throw new NodeNotFoundException();
            else
                return result;
        }

        /// <summary>
        /// Searches for the node with the given value under the tree with the given root
        /// </summary>
        /// <param name="root">The root of the tree to search</param>
        /// <param name="value">The value to find within root</param>
        /// <returns>An instance of IInternalBinaryNode or null if the node was not found</returns>
        private static IInternalBinaryNode<T> FindOrDefault(IInternalBinaryNode<T> root, T value)
        {
            IInternalBinaryNode<T> result;
            if (root == null)
                result = null;
            else
            {
                int compareResult = root.Value.CompareTo(value);
                if (compareResult > 0)
                    result = FindOrDefault(root.Left, value);
                else if (compareResult < 0)
                    result = FindOrDefault(root.Right, value);
                else
                    result = root;
            }

            return result;
        }

        #endregion

        #region Depth

        /// <summary>
        /// Finds the depth of the node with the given value.
        /// 
        /// Throws a TreeNotRootedException if the tree is empty
        /// Throws a NodeNotFoundException if the node was not found
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Depth(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            return Depth(this.Root, value);
        }

        /// <summary>
        /// Finds the depth of the node with the given value underneath the given root
        /// 
        /// Throws a NodeNotFoundException if the node was not found
        /// </summary>
        /// <param name="root">The root of the tree to search</param>
        /// <param name="value">The value of the node whose depth should be returned</param>
        /// <returns></returns>
        private static int Depth(IInternalBinaryNode<T> root, T value)
        {
            if (root == null)
                throw new NodeNotFoundException();

            int compareResult = root.Value.CompareTo(value);
            int result = 0;
            if (compareResult > 0)
                result = Depth(root.Left, value) + 1;
            else if (compareResult < 0)
                result = Depth(root.Right, value) + 1;

            return result;
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the given value into the tree.
        /// 
        /// Throws a ArgumentException if the value already exists in the tree
        /// 
        /// O(log n)
        /// </summary>
        public void Insert(T value)
        {
            this.Root = this.Insert(this.Root,  new BinaryNode<T>(value));
        }

        /// <summary>
        /// Inserts the given node underneath the given root
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal virtual IInternalBinaryNode<T> Insert(IInternalBinaryNode<T> root, IInternalBinaryNode<T> node)
        {
            if (root == null)
            {
                root = node;
                ++this.Count;
            }
            else
            {
                root.ResetHeight();
                int compareResult = root.Value.CompareTo(node.Value);
                if (compareResult > 0)
                    root.Left = Insert(root.Left, node);
                else if (compareResult < 0)
                    root.Right = Insert(root.Right, node);
                else
                    throw new ArgumentException(Resources.Errors.InsertDuplicate);
            }

            return root;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the given value from the tree.
        /// 
        /// Throws a NodeNotFoundException if the value already exists in the tree
        /// Throws a TreeNotRootedException if the tree is empty
        /// 
        /// O(log n)
        /// </summary>
        public void Delete(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            this.Root = Delete(this.Root, value);
        }

        /// <summary>
        /// Deletes the given value from the tree at the given root
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal virtual IInternalBinaryNode<T> Delete(IInternalBinaryNode<T> root, T value)
        {
            if (root == null)
                throw new NodeNotFoundException();
            else
            {
                int compareResults = root.Value.CompareTo(value);
                if (compareResults > 0)
                {
                    root.ResetHeight();
                    root.Left = Delete(root.Left, value);
                }
                else if (compareResults < 0)
                {
                    root.ResetHeight();
                    root.Right = Delete(root.Right, value);
                }
                else
                {
                    if (root.Left == null && root.Right == null)
                    {
                        --this.Count;
                        root = null;
                    }
                    else if (root.Right == null)
                    {
                        --this.Count;
                        root.Value = root.Left.Value;
                        root.Right = root.Left.Right;
                        root.Left = root.Left.Left;
                        root.ResetHeight();
                    }
                    else if (root.Left == null)
                    {
                        --this.Count;
                        root.Value = root.Right.Value;
                        root.Left = root.Right.Left;
                        root.Right = root.Right.Right;
                        root.ResetHeight();
                    }
                    else
                    {
                        IInternalBinaryNode<T> predecessor = BinaryNodeCommon.InOrderPredecessor(root);
                        root.Value = predecessor.Value;
                        root.Left = Delete(root.Left, predecessor.Value);
                    }
                }

                return root;
            }
        }

        #endregion

        #region Iterators

        internal IEnumerable<IInternalBinaryNode<T>> InOrderNodeIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                IInternalBinaryNode<T> current = this.Root;
                Stack<IInternalBinaryNode<T>> parentStack = new Stack<IInternalBinaryNode<T>>();

                while (current != null || parentStack.Count != 0)
                {
                    if (current != null)
                    {
                        parentStack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        current = parentStack.Pop();
                        yield return current;
                        current = current.Right;
                    }
                }
            }
        }

        /// <summary>
        /// Iterates through the tree in order. Visiting the left sub-tree, then the root, then the right sub-tree so that the values are returned in order.
        /// </summary>
        IEnumerable<T> IBinarySearchTree<T>.InOrderIterator
        {
            get
            {
                foreach (IInternalBinaryNode<T> node in this.InOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree in order. Visiting the left sub-tree, then the root, then the right sub-tree so that the values are returned in order.
        /// </summary>
        public IEnumerable<T> InOrderIterator
        {
            get
            {
                foreach (IInternalBinaryNode<T> node in this.InOrderNodeIterator)
                    yield return node.Value;
            }
        }

        internal IEnumerable<IInternalBinaryNode<T>> PostOrderNodeIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                IInternalBinaryNode<T> current;
                IInternalBinaryNode<T> previous = null;
                Stack<IInternalBinaryNode<T>> nodeStack = new Stack<IInternalBinaryNode<T>>();
                nodeStack.Push(this.Root);

                while (nodeStack.Count > 0)
                {
                    current = nodeStack.Peek();
                    if (previous == null || previous.Left == current || previous.Right == current)
                    {
                        if (current.Left != null)
                        {
                            nodeStack.Push(current.Left);
                        }
                        else if (current.Right != null)
                        {
                            nodeStack.Push(current.Right);
                        }
                    }
                    else if (current.Left == previous)
                    {
                        if (current.Right != null)
                            nodeStack.Push(current.Right);
                    }
                    else
                    {
                        yield return current;
                        nodeStack.Pop();
                    }

                    previous = current;
                }
            }
        }

        /// <summary>
        /// Iterates through the tree in post order. Visiting the left sub-tree, then the right sub-tree, then the root. This is useful if you need to dispose of the entire tree as items will be disposed from the bottom up
        /// </summary>
        IEnumerable<T> IBinarySearchTree<T>.PostOrderIterator
        {
            get
            {
                foreach (IInternalBinaryNode<T> node in this.PostOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree in post order. Visiting the left sub-tree, then the right sub-tree, then the root. This is useful if you need to dispose of the entire tree as items will be disposed from the bottom up
        /// </summary>
        public IEnumerable<T> PostOrderIterator
        {
            get
            {
                foreach (IInternalBinaryNode<T> node in this.PostOrderNodeIterator)
                    yield return node.Value;
            }
        }

        internal IEnumerable<IInternalBinaryNode<T>> PreOrderNodeIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                Stack<IInternalBinaryNode<T>> parentStack = new Stack<IInternalBinaryNode<T>>();

                IInternalBinaryNode<T> current = this.Root;

                while (parentStack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        yield return current;

                        parentStack.Push(current.Right);
                        current = current.Left;
                    }
                    else
                    {
                        current = parentStack.Pop();
                    }
                }
            }
        }

        /// <summary>
        /// Iterates through the tree in pre order. Visiting the root, then the left sub-tree, then the right sub-tree. This is useful for algorithms such as the iterative height calculation as it starts at the top and works its way down through the levels
        /// </summary>
        IEnumerable<T> IBinarySearchTree<T>.PreOrderIterator
        {
            get
            {
                foreach (IInternalBinaryNode<T> node in this.PreOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree in pre order. Visiting the root, then the left sub-tree, then the right sub-tree. This is useful for algorithms such as the iterative height calculation as it starts at the top and works its way down through the levels
        /// </summary>
        public IEnumerable<T> PreOrderIterator
        {
            get
            {
                foreach (IInternalBinaryNode<T> node in this.PreOrderNodeIterator)
                    yield return node.Value;
            }
        }

        #endregion

        public virtual void AssertValidTree()
        {
            IInternalBinaryNode<T> previousNode = null;
            foreach (IInternalBinaryNode<T> node in this.InOrderNodeIterator)
            {
                if (previousNode != null && previousNode.Value.CompareTo(node.Value) >= 0)
                        throw new InvalidTreeException();

                previousNode = node;
            }
        }
    }
}
