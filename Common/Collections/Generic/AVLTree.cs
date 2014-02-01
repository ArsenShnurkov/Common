namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A balanced binary tree in which the balance of the root node is always >= -1 and <= 1 ensuring that insert delete and find operations happen in exactly log n time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed partial class AVLTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of an AVLTree
        /// </summary>
        public AVLTree()
        {
            this.Root = null;
            this.Count = 0;
        }

        #endregion

        #region Properties

        internal AVLNode<T> Root { get; set; }

        /// <summary>
        /// Returns the number of nodes in the tree
        /// </summary>
        public int Count { get; internal set; }

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
        private static int Depth(AVLNode<T> root, T value)
        {
            if (root == null)
                throw new ValueNotFoundException(Resources.Errors.DeleteNodeNotFound);

            int compareResult = root.Value.CompareTo(value);
            int result;

            if (compareResult > 0)
                result = Depth(root.Left, value) + 1;
            else if (compareResult < 0)
                result = Depth(root.Right, value) + 1;
            else
                result = 0;

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
            this.Root = this.Insert(this.Root, new AVLNode<T>(value));
        }

        /// <summary>
        /// Inserts the given node underneath the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private AVLNode<T> Insert(AVLNode<T> root, AVLNode<T> node)
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

            root = RebalanceNode(root);

            return root;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the given value from the tree.
        /// 
        /// Throws a NodeNotFoundException if the value doesnt exists in the tree
        /// Throws a TreeNotRootedException if the tree is empty
        /// 
        /// O(log n)
        /// </summary>
        public bool Delete(T value)
        {
            bool result = true;
            try
            {
                if (this.Root != null)
                    this.Root = Delete(this.Root, value);
                else
                    result = false;
            }
            catch (ValueNotFoundException)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Deletes the given value from the tree at the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        private AVLNode<T> Delete(AVLNode<T> root, T value)
        {
            int compareResults = root.Value.CompareTo(value);
            if (compareResults > 0)
            {

                if (root.Left != null)
                {
                    root.ResetHeight();
                    root.Left = Delete(root.Left, value);
                }
                else
                    throw new ValueNotFoundException();
            }
            else if (compareResults < 0)
            {
                if (root.Right != null)
                {
                    root.ResetHeight();
                    root.Right = Delete(root.Right, value);
                }
                else
                    throw new ValueNotFoundException();
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
                    AVLNode<T> predecessor = root.InOrderPredecessor;
                    root.Value = predecessor.Value;
                    root.Left = Delete(root.Left, predecessor.Value);
                    root.ResetHeight();
                }
            }

            if (root != null)
                root = RebalanceNode(root);

            return root;
        }

        #endregion Delete

        #region Rebalancing

        /// <summary>
        /// Rebalances a node if necessary
        /// </summary>
        /// <param name="node">The node to rebalance</param>
        /// <returns>True if a rebalancing was performed</returns>
        private static AVLNode<T> RebalanceNode(AVLNode<T> node)
        {
            // if left tree taller
            if (node.Balance > 1)
                return RebalanceLeftSubTree(node);

            // else if right tree taller
            else if (node.Balance < -1)
                return RebalanceRightSubTree(node);

            return node;
        }

        /// <summary>
        /// Performs the rotations necessary to balance a parent
        /// </summary>
        /// <param name="parent">The parent node to rebalance</param>
        private static AVLNode<T> RebalanceRightSubTree(AVLNode<T> parent)
        {
            // Converts a Root -> Right -> Left sub tree
            // Into a Root -> Right -> Right sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Right.Balance > 0)
                parent.Right = parent.Right.RotateRight();

            return parent.RotateLeft();
        }

        /// <summary>
        /// Performs the rotations necessary to balance a parent
        /// </summary>
        /// <param name="parent">The parent node to rebalance</param>
        private static AVLNode<T> RebalanceLeftSubTree(AVLNode<T> parent)
        {
            // Converts a Root -> Left -> Right sub tree
            // Into a Root -> Left -> Left sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Left.Balance < 0)
                parent.Left = parent.Left.RotateLeft();

            return parent.RotateRight();
        }

        #endregion

        #region Node Iterators

        private IEnumerable<AVLNode<T>> InOrderNodeIterator
        {
            get
            {
                AVLNode<T> current = this.Root;
                Stack<AVLNode<T>> parentStack = new Stack<AVLNode<T>>();

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

        private IEnumerable<AVLNode<T>> PostOrderNodeIterator
        {
            get
            {
                AVLNode<T> current;
                AVLNode<T> previous = null;
                Stack<AVLNode<T>> nodeStack = new Stack<AVLNode<T>>();

                if (this.Root != null)
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

        private IEnumerable<AVLNode<T>> PreOrderNodeIterator
        {
            get
            {
                Stack<AVLNode<T>> parentStack = new Stack<AVLNode<T>>();

                AVLNode<T> current = this.Root;

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

        #endregion

        #region Value Iterators

        /// <summary>
        /// Iterates through the tree in order. Visiting the left sub-tree, then the root, then the right sub-tree so that the values are returned in order.
        /// </summary>
        public IEnumerable<T> InOrderIterator
        {
            get
            {
                foreach (AVLNode<T> node in this.InOrderNodeIterator)
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
                foreach (AVLNode<T> node in this.PostOrderNodeIterator)
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
                foreach (AVLNode<T> node in this.PreOrderNodeIterator)
                    yield return node.Value;
            }
        }

        #endregion

        #region Public Methods

        public void AssertValidTree()
        {
            if (this.Root != null)
            {
                AVLNode<T> previousNode = null;
                foreach (AVLNode<T> node in this.InOrderNodeIterator)
                {
                    if (previousNode != null && previousNode.Value.CompareTo(node.Value) >= 0)
                        throw new InvalidTreeException();

                    node.ResetHeight();
                    if (node.Balance < -1 || node.Balance > 1)
                        throw new InvalidTreeException();

                    previousNode = node;
                }
            }
        }

        #endregion
    }
}
