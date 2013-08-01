namespace Common.Collections.Generic
{
    using System.Collections.Generic;

    public class BinaryNode<T> : INode<T>, IBinaryNode<T>, IInternalBinaryNode<T>
    {
        /// <summary>
        /// Creates a new instance of a Common.Collections.Generic.BinaryNode<T>
        /// </summary>
        /// <param name="value">The data value that this node will contain</param>
        public BinaryNode(T value)
        {
            this._height    = null;
            this.Value      = value;
        }

        #region Properties

        public T Value { get; internal set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        public BinaryNode<T> Left { get; internal set; }

        /// <summary>
        /// Points to the right sub tree of this node
        /// </summary>
        public BinaryNode<T> Right { get; internal set; }

        /// <summary>
        /// Returns true if this node has no neighbours
        /// </summary>
        public bool IsLeaf
        {
            get
            {
                return (this.Left == null && this.Right == null);
            }
        }

        private int? _height;

        /// <summary>
        /// The height of the node.
        /// 
        /// O(1) - When cached
        /// O(log n) - Otherwise
        /// </summary>
        public int Height
        {
            get
            {
                if (!this._height.HasValue)
                {
                    this._height = BinaryNodeCommon.GetHeight(this);
                }

                return this._height.Value;
            }
        }

        /// <summary>
        /// The balance of the node. Node.Balance = Node.Left.Height - Node.Right.Height
        /// 
        /// O(log n) when one or more heights below this one aren't cached
        /// O(1) otherwise
        /// </summary>
        public int Balance
        {
            get
            {
                int balance = BinaryNodeCommon.GetNodeBalance(this);

                return balance;
            }
        }

        public BinaryNode<T> InOrderPredecessor
        {
            get { return BinaryNodeCommon.InOrderPredecessor(this) as BinaryNode<T>; }
        }

        public BinaryNode<T> InOrderSuccessor
        {
            get { return BinaryNodeCommon.InOrderSuccessor(this) as BinaryNode<T>; }
        }

        public IEnumerable<BinaryNode<T>> Neighbours
        {
            get { return new BinaryNode<T>[2] { this.Left, this.Right }; }
        }

        #endregion

        #region IInternalBinaryNode Explicit Implementation

        T IInternalBinaryNode<T>.Value
        {
            get { return this.Value; }
            set { this.Value = value; }
        }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.Left
        {
            get { return this.Left; }
            set { this.Left = value as BinaryNode<T>; }
        }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.Right
        {
            get { return this.Right; }
            set { this.Right = value as BinaryNode<T>; }
        }

        /// <summary>
        /// Marks the height of the node to be recalculated next time it is accessed
        /// </summary>
        void IInternalBinaryNode<T>.ResetHeight()
        {
            this.ResetHeight();
        }

        #endregion

        #region IBinaryNode Explicit Implementation

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        IBinaryNode<T> IBinaryNode<T>.Left
        {
            get { return this.Left; }
        }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        IBinaryNode<T> IBinaryNode<T>.Right
        {
            get { return this.Right; }
        }

        #endregion

        #region INode Explicit Implementation

        /// <summary>
        /// Returns an enumerable list of neighbouring ndoes
        /// </summary>
        IEnumerable<INode<T>> INode<T>.Neighbours
        {
            get { return this.Neighbours; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Marks the height of the node to be recalculated next time it is accessed
        /// </summary>
        internal void ResetHeight()
        {
            this._height = null;
        }

        public override string ToString()
        {
            string format = "{0}; Left={1}; Right={2}";

            string left;
            if (this.Left == null)
                left = "null";
            else
                left = this.Left.Value.ToString();

            string right;
            if (this.Right == null)
                right = "null";
            else
                right = this.Right.Value.ToString();

            return string.Format(format, this.Value.ToString(), left, right);
        }

        #endregion
    }
}