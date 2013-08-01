namespace Common.Collections.Generic
{
    using System.Collections.Generic;

    public class RedBlackNode<T> : IBinaryNode<T>, IInternalBinaryNode<T>
    {
        public RedBlackNode(T value)
        {
            this.Left       = null;
            this.Right      = null;
            this.Colour     = Colour.Red;
            this.Value      = value;
            this._height    = null;
        }

        #region Properties

        public T Value { get; internal set; }

        /// <summary>
        /// The colour of the node.
        /// </summary>
        internal Colour Colour { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        public RedBlackNode<T> Left { get; internal set; }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        public RedBlackNode<T> Right { get; internal set; }

        private int? _height;

        /// <summary>
        /// The height of the tree.
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
        /// The balance of the tree. Root.Balance = Root.Left.Height - Root.Right.Height
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

        public RedBlackNode<T> InOrderPredecessor
        {
            get { return BinaryNodeCommon.InOrderPredecessor(this) as RedBlackNode<T>; }
        }

        public RedBlackNode<T> InOrderSuccessor
        {
            get { return BinaryNodeCommon.InOrderSuccessor(this) as RedBlackNode<T>; }
        }

        public IEnumerable<RedBlackNode<T>> Neighbours
        {
            get { return new RedBlackNode<T>[2] { this.Left, this.Right }; }
        }

        #endregion

        #region Rotations

        /// <summary>
        /// Rotates the tree rooted at this node in a counter-clockwise manner and recolours the root and pivot nodes accordingly.
        /// </summary>
        /// <returns>The new root of the tree</returns>
        internal RedBlackNode<T> RotateLeft()
        {
            RedBlackNode<T> root = BinaryNodeCommon.RotateLeft(this) as RedBlackNode<T>;
            root.Left.Colour = Colour.Red;
            root.Colour = Colour.Black;
            return root;
        }

        /// <summary>
        /// Rotates the tree rooted at this node in a clockwise manner and recolours the root and pivot nodes accordingly.
        /// </summary>
        /// <returns>The new root of the tree</returns>
        internal RedBlackNode<T> RotateRight()
        {
            RedBlackNode<T> root = BinaryNodeCommon.RotateRight(this) as RedBlackNode<T>;
            root.Right.Colour = Colour.Red;
            root.Colour = Colour.Black;
            return root;
        }

        #endregion

        #region Methods

        public void ResetHeight()
        {
            this._height = null;
        }

        #endregion

        #region IInternalBinaryNode Explicit Implementation

        T IInternalBinaryNode<T>.Value
        {
            get { return this.Value; }
            set { this.Value = value; }
        }

        IInternalBinaryNode<T> IInternalBinaryNode<T>.Left
        {
            get { return this.Left; }
            set { this.Left = value as RedBlackNode<T>; }
        }

        IInternalBinaryNode<T> IInternalBinaryNode<T>.Right
        {
            get { return this.Right; }
            set { this.Right = value as RedBlackNode<T>; }
        }

        void IInternalBinaryNode<T>.ResetHeight()
        {
            this._height = null;
        }

        #endregion

        #region IBinaryNode Explicit Implementation

        IBinaryNode<T> IBinaryNode<T>.Left
        {
            get { return this.Left; }
        }

        IBinaryNode<T> IBinaryNode<T>.Right
        {
            get { return this.Right; }
        }

        #endregion

        #region INode Explicit Implementation

        IEnumerable<INode<T>> INode<T>.Neighbours
        {
            get { return this.Neighbours; }
        }

        #endregion
    }
}
