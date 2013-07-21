namespace Common.Collections.Generic
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the interface for a generic node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INode<T>
    {
        /// <summary>
        /// Returns true if this node has no neighbours
        /// </summary>
        bool IsLeaf { get; }

        /// <summary>
        /// Returns an enumerable list of neighbouring ndoes
        /// </summary>
        IEnumerable<INode<T>> Neighbours { get; }

        /// <summary>
        /// The data value stored in the node
        /// </summary>
        T Value { get; }
    }
}
