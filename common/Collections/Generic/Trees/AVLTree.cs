namespace Common.Collections.Generic
{
    using System;
    using Common.Resources;

    /// <summary>
    /// A balanced binary tree in which the balance of the root node is always >= -1 and <= 1 ensuring that insert delete and find operations happen in exactly log n time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTree<T> : BinarySearchTree<T>, IBinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Creates a new instance of an AVLTree
        /// </summary>
        public AVLTree()
            : base()
        {
        }

        #region Insert Delete Helper Methods

        /// <summary>
        /// Resets the height of the node and then rebalances it
        /// 
        /// O(log n) - dependent on height of node
        /// O(1) - For the rebalancing
        /// </summary>
        /// <param name="node"></param>
        protected override void ProcessParentNode(BinaryNode<T> node)
        {
            base.ProcessParentNode(node);
            RebalanceNode(node);
        }

        #endregion

        #region Rebalancing

        /// <summary>
        /// Rebalances a node if necessary
        /// </summary>
        /// <param name="node">The node to rebalance</param>
        /// <returns>True if a rebalancing was performed</returns>
        private static bool RebalanceNode(BinaryNode<T> node)
        {
            bool balancePerformed = node.Balance != 0;

            // if left tree taller
            if (node.Balance > 1)
                RebalanceLeftSubTree(node);

            // else if right tree taller
            else if (node.Balance < -1)
                RebalanceRightSubTree(node);

            return balancePerformed;
        }

        /// <summary>
        /// Performs the rotations necessary to balance a parent
        /// </summary>
        /// <param name="parent">The parent node to rebalance</param>
        private static void RebalanceRightSubTree(BinaryNode<T> parent)
        {
            if (parent.Balance >= -1)
                throw new ArgumentException(Errors.CannotRebalanceInThisDirection);

            // Converts a Root -> Right -> Left sub tree
            // Into a Root -> Right -> Right sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Right.Balance > 0)
                parent.Right.RotateRight();

            parent.RotateLeft();
        }

        /// <summary>
        /// Performs the rotations necessary to balance a parent
        /// </summary>
        /// <param name="parent">The parent node to rebalance</param>
        private static void RebalanceLeftSubTree(BinaryNode<T> parent)
        {
            if (parent.Balance <= 1)
                throw new ArgumentException(Errors.CannotRebalanceInThisDirection);

            // Converts a Root -> Left -> Right sub tree
            // Into a Root -> Left -> Left sub tree maintaining order
            // So that we can do the standard rotate
            if (parent.Left.Balance < 0)
                parent.Left.RotateLeft();

            parent.RotateRight();
        }

        #endregion

    }
}
