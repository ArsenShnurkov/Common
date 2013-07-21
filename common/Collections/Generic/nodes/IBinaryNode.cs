namespace Common.Collections.Generic
{

    /// <summary>
    /// A specialization of an INode that has a left and a right child.
    /// </summary>
    /// <typeparam name="T">The type of data to store in the IBinaryNode</typeparam>
    public interface IBinaryNode<T> : INode<T>
    {
        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        IBinaryNode<T> Left { get; }

        /// <summary>
        /// Points to the right sub tree of this node
        /// </summary>
        IBinaryNode<T> Right { get; }

        /// <summary>
        /// The height of the tree.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// The balance of the tree. Root.Balance = Root.Left.Height - Root.Right.Height
        /// </summary>
        int Balance { get; }
    }
}
