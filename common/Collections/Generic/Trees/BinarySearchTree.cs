namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using Common.Resources;

    /// <summary>
    /// This is an orderdered binary tree in which all nodes in left sub tree are smaller than the root, and all nodes in right sub tree are larger than the root. This holds true for all sub trees of this tree as well
    /// </summary>
    /// <typeparam name="T">The type that will be stored in the nodes of the tree</typeparam>
    public partial class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Creates a new instance of a Common.Collections.Generic.BinarySearchTree<T>
        /// </summary>
        public BinarySearchTree()
        {
        }

        #region Properties

        /// <summary>
        /// The root of the tree
        /// </summary>
        internal BinaryNode<T> Root { get; set; }

        /// <summary>
        /// The number of values stored in this tree
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// The height of the tree.The height of a tree that has a leaf for a root is 0. The height of an empty tree is -1
        /// 
        /// O(log n) when not cached
        /// O(1) when cached
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
        /// Balance = Root.Left.Height - Root.Right.Height
        /// 
        /// O(1) whwn cached
        /// O(log n) when not cached
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

        /// <summary>
        /// Returns the length of the path from the root to the node
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value of the node whose depth we want to find</param>
        /// <returns>The node's depth</returns>
        public int Depth(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            BinaryNode<T> current = this.Root;
            int depth = 0;

            while (current != null)
            {
                int compareValue = current.Value.CompareTo(value);
                if (compareValue == 0)
                {
                    break;
                }
                else if (compareValue > 0)
                {
                    current = current.Left;
                }
                else
                    current = current.Right;

                ++depth;
            }

            if (current != null)
                return depth;
            else
                throw new NodeNotFoundException(Errors.DepthNodeNotFound);
        }

        /// <summary>
        /// Given a collection of parent nodes this method will loop through them all
        /// for post insert/delete processing
        /// </summary>
        /// <param name="parents">The stack of parent nodes to process</param>
        private void ProcessParentNodes(Stack<BinaryNode<T>> parents)
        {
            while (parents.Count > 0)
            {
                BinaryNode<T> current = parents.Pop();
                this.ProcessParentNode(current);
            }
        }

        /// <summary>
        /// Processes one ancestor node during an insert or delete operation
        /// </summary>
        /// <param name="node">The node to process.</param>
        protected virtual void ProcessParentNode(BinaryNode<T> node)
        {
            node.ResetHeight();
        }

        #region Find

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
        public IBinaryNode<T> FindOrDefault(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            BinaryNode<T> current = this.Root;
            while (current != null)
            {
                int compareResult = current.Value.CompareTo(value);
                if (compareResult == 0)
                    break;
                else if (compareResult > 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return current;
        }

        /// <summary>
        /// Looks for a node with a matching value in this tree. Throws a NodeNotFoundException if the node was not located
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value of the node to find</param>
        /// <returns>
        /// the node that was found
        /// </returns>
        public IBinaryNode<T> Find(T value)
        {
            IBinaryNode<T> result = this.FindOrDefault(value);

            if (result != null)
                return result;
            else
                throw new NodeNotFoundException(Errors.NotFound);
        }

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the node in to the tree in order. Throws a ArgumentException if this node was a duplicate of one that already exists in the tree
        /// </summary>
        /// <param name="node">The node to insert</param>
        protected void Insert(BinaryNode<T> node)
        {
            if (this.Root == null)
            {
                this.Root = node;
            }
            else
            {
                Stack<BinaryNode<T>> parents = new Stack<BinaryNode<T>>(this.Height);

                BinaryNode<T> current = this.Root;
                while (current != null)
                {
                    int compareResult = current.Value.CompareTo(node.Value);
                    if (compareResult == 0)
                    {
                        throw new ArgumentException(Errors.InsertDuplicate);
                    }
                    //value is smaller than Root.Value
                    else if (compareResult > 0)
                    {
                        parents.Push(current);
                        if (current.Left != null)
                        {
                            current = current.Left;
                        }
                        else// found leaf - insert here
                        {
                            current.Left = node;
                            break;
                        }
                    }
                    //value is larger than Root.Value
                    else
                    {
                        parents.Push(current);
                        if (current.Right != null)
                        {
                            current = current.Right;
                        }
                        else // found leaf - insert here
                        {
                            current.Right = node;
                            break;
                        }
                    }
                }

                parents.Push(node);
                this.ProcessParentNodes(parents);
            }

            ++this.Count;
        }

        /// <summary>
        /// Inserts a new node with the given value in to the tree in order. Throws a ArgumentException if this node was a duplicate of one that already exists in the tree
        /// </summary>
        /// <param name="node">The value to insert</param>
        public virtual void Insert(T value)
        {
            var node = new BinaryNode<T>(value);
            this.Insert(node);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the node that is passed in
        /// </summary>
        /// <param name="node">The node to delete</param>
        /// <param name="parentNode">the parent of the node we are deleting</param>
        internal void DeleteNode(BinaryNode<T> node, BinaryNode<T> parentNode)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            int compareResults;
            if (parentNode != null)
                compareResults = node.Value.CompareTo(parentNode.Value);
            else
                compareResults = 0;

            if (node.IsLeaf && this.Root.Value.CompareTo(node.Value) == 0)
            {
                this.Root = null;
            }
            else if (node.IsLeaf)
            {
                if (compareResults < 0)
                    parentNode.Left = null;
                else
                    parentNode.Right = null;

                --this.Count;
            }
            else if (node.Right == null)
            {
                if (compareResults < 0)
                    parentNode.Left = node.Left;
                else
                    parentNode.Right = node.Left;

                --this.Count;
            }
            else if (node.Left == null)
            {
                if (compareResults < 0)
                    parentNode.Left = node.Right;
                else
                    parentNode.Right = node.Right;

                --this.Count;
            }
            else // if both children not null
            {
                BinaryNode<T> swapNode = node.InOrderPredecessor;
                if (swapNode == null)
                    throw new InvalidOperationException(Errors.NoSwapNode);

                T tempValue = swapNode.Value;
                this.Delete(swapNode.Value);
                node.Value = tempValue;
            }
        }

        /// <summary>
        /// Deletes the node with the given value from the tree and deletes that node. Throws a NodeNotFoundException otherwise
        /// 
        /// O(log n)
        /// </summary>
        /// <param name="value">The value to delete from the tree</param>
        /// <returns>The node that was deleted</returns>
        public IBinaryNode<T> Delete(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            BinaryNode<T> previous = null;
            BinaryNode<T> current = this.Root;

            Stack<BinaryNode<T>> parents = new Stack<BinaryNode<T>>(this.Height);

            while (current != null)
            {
                int compareResult = current.Value.CompareTo(value);
                if (compareResult == 0)
                    break;
                else if (compareResult > 0)
                {
                    parents.Push(current);
                    previous = current;
                    current = (BinaryNode<T>)current.Left;
                }
                else
                {
                    parents.Push(current);
                    previous = current;
                    current = (BinaryNode<T>)current.Right;
                }
            }

            if (current == null)
                throw new NodeNotFoundException(Errors.DeleteNodeNotFound);
            else
                this.DeleteNode(current, previous);

            this.ProcessParentNodes(parents);

            return current;
        }

        #endregion

        #region Iterators

        /// <summary>
        /// Iterates through the tree using the in order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        protected IEnumerable<BinaryNode<T>> InOrderNodeIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                BinaryNode<T> current = this.Root;
                Stack<BinaryNode<T>> parentStack = new Stack<BinaryNode<T>>();

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
        /// Iterates through the tree using the in post order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        protected IEnumerable<BinaryNode<T>> PostOrderNodeIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                BinaryNode<T> current;
                BinaryNode<T> previous = null;
                Stack<BinaryNode<T>> nodeStack = new Stack<BinaryNode<T>>();
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
        /// Iterates through the tree using the in pre order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        protected IEnumerable<BinaryNode<T>> PreOrderNodeIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                Stack<BinaryNode<T>> parentStack = new Stack<BinaryNode<T>>();

                BinaryNode<T> current = this.Root;

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
        /// Iterates through the tree using the in order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> InOrderIterator
        {
            get
            {
                foreach (var node in this.InOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree using the post order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> PostOrderIterator
        {
            get
            {
                foreach (var node in this.PostOrderNodeIterator)
                    yield return node.Value;
            }
        }

        /// <summary>
        /// Iterates through the tree using the pre order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> PreOrderIterator
        {
            get
            {
                foreach (var node in this.PreOrderNodeIterator)
                    yield return node.Value;
            }
        }

        #endregion
    }
}
