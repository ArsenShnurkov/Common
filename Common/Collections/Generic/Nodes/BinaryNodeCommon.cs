namespace Common.Collections.Generic
{
    using System;
    using System.Runtime.CompilerServices;

    internal static class BinaryNodeCommon
    {

        /// <summary>
        /// Returns the in order predecessor of this node if one exists or null otherwise
        /// </summary>
        internal static IInternalBinaryNode<T> InOrderPredecessor<T>(IInternalBinaryNode<T> node)
        {
            IInternalBinaryNode<T> previous = null;
            IInternalBinaryNode<T> current = node.Left;
            while (current != null)
            {
                previous = current;
                current = current.Right;
            }

            return previous;
        }

        /// <summary>
        /// Returns the in order successor of this node if one exists or null otherwise
        /// </summary>
        internal static IInternalBinaryNode<T> InOrderSuccessor<T>(IInternalBinaryNode<T> node)
        {
            IInternalBinaryNode<T> previous = null;
            IInternalBinaryNode<T> current = node.Right;
            while (current != null)
            {
                previous = current;
                current = current.Left;
            }

            return previous;
        }

        /// <summary>
        /// Returns the height of a node that is potentially null
        /// </summary>
        /// <typeparam name="T">The data type contained within the node</typeparam>
        /// <param name="node">The child node that we want the height for</param>
        /// <returns>-1 if the node is null. Otherwise it returns the cached node height</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetNodeChildHeight<T>(IInternalBinaryNode<T> node)
        {
            return (node == null) ? -1 : node.Height;
        }

        /// <summary>
        /// Retrieves the height of the node calculated as Height = Max(Left.Height, Right.Height) + 1
        /// 
        /// The height of a tree that only has a root is 0
        /// </summary>
        /// <typeparam name="T">The data type contained within the node</typeparam>
        /// <param name="node">The node who's height needs to be calculated</param>
        internal static int GetNodeHeight<T>(IInternalBinaryNode<T> node)
        {
            return Math.Max(GetNodeChildHeight(node.Left), GetNodeChildHeight(node.Right)) + 1;
        }

        /// <summary>
        /// Retrieves the balance of a node calculated as node.Balance = Node.Left.Balance - Node.Right.Balance
        /// </summary>
        internal static int GetNodeBalance<T>(IInternalBinaryNode<T> node)
        {
            return GetNodeChildHeight(node.Left) - GetNodeChildHeight(node.Right);
        }
    }
}
