namespace Common.Collections.Generic
{

    /// <summary>
    /// This internal interface represents a Binary Node. This interface serves as a comprimise between
    /// good design and speed. While I would prefer it if, for example, the RedBlackNode inherited from BinaryNode,
    /// this actually introduces quite a few extra casts and virtual functions in the BinaryTree and the RedBlackTree
    /// which tend to slow it down.
    /// </summary>
    /// <typeparam name="T">The type of data to store in the IBinaryNode</typeparam>
    internal interface IInternalBinaryNode<T>
    {
        #region Properties 

        T Value { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> Left { get; set; }

        /// <summary>
        /// Points to the right sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> Right { get; set; }

        /// <summary>
        /// Returns true if this node has no children
        /// </summary>
        bool IsLeaf { get; }

        /// <summary>
        /// The height of the tree.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// The balance of the tree. Root.Balance = Root.Left.Height - Root.Right.Height
        /// </summary>
        int Balance { get; }

        /// <summary>
        /// Returns the node that immediately comes before this node if they were listed in order
        /// </summary>
        IInternalBinaryNode<T> InOrderPredecessor { get; }

        /// <summary>
        /// Returns the node that immediately comes after this node if they were listed in order
        /// </summary>
        IInternalBinaryNode<T> InOrderSuccessor { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Marks the height of the node to be recalculated next time it is accessed
        /// </summary>
        void ResetHeight();

        /// <summary>
        /// Rotates the node and it's chidren in a counter clockwise manner.
        /// </summary>
        /// <returns></returns>
        IInternalBinaryNode<T> RotateLeft();

        /// <summary>
        /// Rotates the ndoe and it's chidren in a clockwise manner.
        /// </summary>
        /// <returns></returns>
        IInternalBinaryNode<T> RotateRight();

        #endregion
    }
}
