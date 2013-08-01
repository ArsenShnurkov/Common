namespace Common.Collections.Generic
{

    /// <summary>
    /// A specialization of an INode that has a left and a right child.
    /// </summary>
    /// <typeparam name="T">The type of data to store in the IBinaryNode</typeparam>
    internal interface IInternalBinaryNode<T> : IBinaryNode<T>, INode<T>
    {
        new T Value { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        new IInternalBinaryNode<T> Left { get; set; }

        /// <summary>
        /// Points to the right sub tree of this node
        /// </summary>
        new IInternalBinaryNode<T> Right { get; set; }
        
        /// <summary>
        /// Marks the height of the node to be recalculated next time it is accessed
        /// </summary>
        void ResetHeight();
    }
}
