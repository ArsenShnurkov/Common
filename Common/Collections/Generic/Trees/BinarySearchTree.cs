namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using Common.Resources;

    /// <summary>
    /// This is an unbalanced binary search implemented using iterative algorithms so as to never encounter a stack overflow.
    /// 
    /// Based on my timings this tree is faster than the recusive BinarySearchTreeBase class. However it is only good on it's own.
    /// When a parent node stack is maintained in the insert and delete operations in order to support inheritance from an
    /// AVLTree for rebalancing, the iterative binary search tree becomes twice as slow as its recursive counterpart.
    /// 
    /// So. If you only need a basic BST use the BinarySearchTree.
    /// </summary>
    /// <typeparam name="T">The type that will be stored in the nodes of the tree</typeparam>
    public sealed partial class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
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
        internal IterativeBinaryNode<T> Root { get; set; }

        /// <summary>
        /// The number of values stored in this tree
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// The height of the tree.The height of a tree that has a leaf for a root is 0. The height of an empty tree is -1
        /// 
        /// O(n)
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
        /// O(n)
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

        #region Depth

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

            IterativeBinaryNode<T> current = this.Root;
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

        #endregion

        #region Insert

        /// <summary>
        /// Inserts the node in to the tree in order. Throws a ArgumentException if this node was a duplicate of one that already exists in the tree
        /// </summary>
        /// <param name="node">The node to insert</param>
        internal void Insert(IterativeBinaryNode<T> node)
        {
            if (this.Root == null)
            {
                this.Root = node;
            }
            else
            {
                IterativeBinaryNode<T> current = this.Root;
                while (true)
                {
                    int compareResult = current.Value.CompareTo(node.Value);
                    if (compareResult == 0)
                    {
                        throw new ArgumentException(Errors.InsertDuplicate);
                    }
                    //value is smaller than current.Value
                    else if (compareResult > 0)
                    {
                        if (current.Left != null)
                        {
                            current = current.Left;
                        }
                        else //found leaf - insert here
                        {
                            current.Left = node;
                            break;
                        }
                    }
                    //value is larger than current.Value
                    else
                    {
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
            }

            ++this.Count;
        }

        /// <summary>
        /// Inserts a new node with the given value in to the tree in order. Throws a ArgumentException if this node was a duplicate of one that already exists in the tree
        /// </summary>
        /// <param name="node">The value to insert</param>
        public void Insert(T value)
        {
            var node = new IterativeBinaryNode<T>(value);
            this.Insert(node);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the node that is passed in
        /// </summary>
        /// <param name="node">The node to delete</param>
        /// <param name="parentNode">the parent of the node we are deleting</param>
        internal void DeleteNode(IterativeBinaryNode<T> node, IterativeBinaryNode<T> parentNode)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            int compareResults;
            if (parentNode != null)
                compareResults = node.Value.CompareTo(parentNode.Value);
            else
                compareResults = 0;

            bool isLeaf = node.IsLeaf;
            if (node.IsLeaf && this.Root.Value.CompareTo(node.Value) == 0)
            {
                this.Root = null;
                --this.Count;
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
                IterativeBinaryNode<T> swapNode = node.InOrderPredecessor;
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
        public void Delete(T value)
        {
            if (this.Root == null)
                throw new TreeNotRootedException();

            IterativeBinaryNode<T> previous = null;
            IterativeBinaryNode<T> current = this.Root;

            while (current != null)
            {
                int compareResult = current.Value.CompareTo(value);
                if (compareResult == 0)
                    break;
                else if (compareResult > 0)
                {
                    previous = current;
                    current = current.Left;
                }
                else
                {
                    previous = current;
                    current = current.Right;
                }
            }

            if (current == null)
                throw new NodeNotFoundException(Errors.DeleteNodeNotFound);
            else
                this.DeleteNode(current, previous);
        }

        #endregion

        #region Iterators

        /// <summary>
        /// Iterates through the tree using the in order traversal algorithm
        /// 
        /// O(n)
        /// </summary>
        public IEnumerable<T> InOrderIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                IterativeBinaryNode<T> current = this.Root;
                Stack<IterativeBinaryNode<T>> parentStack = new Stack<IterativeBinaryNode<T>>();

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
                        yield return current.Value;
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
        public IEnumerable<T> PostOrderIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                IterativeBinaryNode<T> current;
                IterativeBinaryNode<T> previous = null;
                Stack<IterativeBinaryNode<T>> nodeStack = new Stack<IterativeBinaryNode<T>>();
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
                        yield return current.Value;
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
        public IEnumerable<T> PreOrderIterator
        {
            get
            {
                if (this.Root == null)
                    throw new TreeNotRootedException();

                Stack<IterativeBinaryNode<T>> parentStack = new Stack<IterativeBinaryNode<T>>();

                IterativeBinaryNode<T> current = this.Root;

                while (parentStack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        yield return current.Value;

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

        #endregion

        public void AssertValidTree()
        {
            bool first = true;
            T previousValue = default(T);
            foreach (T value in this.InOrderIterator)
            {
                if (!first && previousValue.CompareTo(value) >= 0)
                    throw new InvalidTreeException();

                previousValue = value;
                first = false;
            }

        }
    }
}
