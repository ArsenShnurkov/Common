namespace Common.Collections.Generic
{
    using System;

    /// <summary>
    /// A balanced binary tree in which the balance of the root node is always >= -1 and <= 1 ensuring that insert delete and find operations happen in exactly log n time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTree<T> : BinarySearchTreeBase<T>, IBinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Creates a new instance of an AVLTree
        /// </summary>
        public AVLTree()
            : base()
        {
        }

        #region Insert

        /// <summary>
        /// Inserts the given node underneath the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="node">The node to insert</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal override IInternalBinaryNode<T> Insert(IInternalBinaryNode<T> root, IInternalBinaryNode<T> node)
        {
            root = base.Insert(root, node);
            root = RebalanceNode(root);
            return root;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the given value from the tree at the given root according to the BinarySearchTree algorithm and then
        /// rebalances the tree.
        /// </summary>
        /// <param name="root">The root node of the tree</param>
        /// <param name="value">The value to delete</param>
        /// <returns>The new root of the tree as it may have changed</returns>
        internal override IInternalBinaryNode<T> Delete(IInternalBinaryNode<T> root, T value)
        {
            root = base.Delete(root, value);

            if (root != null)
            {
                root = RebalanceNode(root);
                root.ResetHeight();
            }

            return root;
        }

        #endregion Delete

        #region Rebalancing

        /// <summary>
        /// Rebalances a node if necessary
        /// </summary>
        /// <param name="node">The node to rebalance</param>
        /// <returns>True if a rebalancing was performed</returns>
        private static IInternalBinaryNode<T> RebalanceNode(IInternalBinaryNode<T> node)
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
        private static IInternalBinaryNode<T> RebalanceRightSubTree(IInternalBinaryNode<T> parent)
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
        private static IInternalBinaryNode<T> RebalanceLeftSubTree(IInternalBinaryNode<T> parent)
        {
            // Converts a Root -> Left -> Right sub tree
            // Into a Root -> Left -> Left sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Left.Balance < 0)
                parent.Left = parent.Left.RotateLeft();

            return parent.RotateRight();
        }

        #endregion

        public override void AssertValidTree()
        {
            base.AssertValidTree();

            foreach (IInternalBinaryNode<T> node in this.PostOrderNodeIterator)
            {
                node.ResetHeight();
                if (node.Balance < -1 || node.Balance > 1)
                    throw new InvalidTreeException();
            }
        }
    }
}
