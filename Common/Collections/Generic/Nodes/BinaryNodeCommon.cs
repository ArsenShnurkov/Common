namespace Common.Collections.Generic
{
    using System;

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
        /// Retrieves the height of the node calculated as Height = Max(Left.Height, Right.Height) + 1
        /// 
        /// The height of a tree that only has a root is 0
        /// </summary>
        /// <typeparam name="T">The data type contained within the node</typeparam>
        /// <param name="node">The node who's height needs to be calculated</param>
        internal static int GetHeight<T>(IInternalBinaryNode<T> node)
        {
            int height;
            if (node.IsLeaf)
                height = 0;
            else if (node.Right == null)
                height = node.Left.Height + 1;
            else if (node.Left == null)
                height = node.Right.Height + 1;
            else
                height = Math.Max(node.Left.Height, node.Right.Height) + 1;

            return height;
        }

        /// <summary>
        /// Retrieves the balance of a node calculated as node.Balance = Node.Left.Balance - Node.Right.Balance
        /// </summary>
        internal static int GetNodeBalance<T>(IInternalBinaryNode<T> node)
        {
            int balance;
            if (node.IsLeaf)
                balance = 0;
            else if (node.Right == null)
                balance = node.Left.Height + 1;
            else if (node.Left == null)
                balance = -1 - node.Right.Height;
            else
                balance = node.Left.Height - node.Right.Height;
            return balance;
        }

        // Rotates a tree around R                     Resulting in
        // 
        //        R                                        B
        //       / \                                      / \
        //      A    B                                   R   F
        //     / \  / \                                 / \
        //    C   D E  F                               A   E
        //                                            / \    
        //                                           C   D
        //                                           
        /// <summary>
        /// Rotates the tree rooted at this node in a counter-clockwise manner
        /// </summary>
        /// <returns>The new root of the tree</returns>
        internal static IInternalBinaryNode<T> RotateLeft<T>(IInternalBinaryNode<T> node)
        {
            IInternalBinaryNode<T> pivot = node.Right;

            node.Right = pivot.Left;
            pivot.Left = node;

            //fix heights
            pivot.ResetHeight();
            node.ResetHeight();

            return pivot;
        }

        // Rotates a tree around R                    Resulting in
        // 
        //        R                                        A
        //       / \                                      / \
        //      A    B                                   C   R
        //     / \  / \                                     / \
        //     C  D E  F                                   D   B
        //                                                    / \          
        //                                                   E   F
        //  
        /// <summary>
        /// Rotates the tree rooted at this node in a clockwise manner
        /// </summary>
        /// <returns>The new root of the tree</returns>
        internal static IInternalBinaryNode<T> RotateRight<T>(IInternalBinaryNode<T> node)
        {
            IInternalBinaryNode<T> pivot = node.Left;

            node.Left = pivot.Right;
            pivot.Right = node;

            //fix heights
            pivot.ResetHeight();
            node.ResetHeight();

            return pivot;
        }
    }
}
