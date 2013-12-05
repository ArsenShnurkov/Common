namespace Common.Collections.Generic
{
    internal class RedBlackNode<T> : IInternalBinaryNode<T>
    {
        internal RedBlackNode(T value)
        {
            this.Colour = Colour.Red;
            this.Left = null;
            this.Right = null;
            this._height = int.MinValue;
            this.Value = value;
        }

        #region Properties

        internal T Value { get; set; }
        T IInternalBinaryNode<T>.Value
        {
            get { return this.Value; }
            set { this.Value = Value; }
        }

        /// <summary>
        /// The colour of the node.
        /// </summary>
        internal Colour Colour { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        internal RedBlackNode<T> Left { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.Left
        {
            get { return this.Left; }
            set { this.Left = (RedBlackNode<T>)value; }
        }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        internal RedBlackNode<T> Right { get; set; }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.Right
        {
            get { return this.Right; }
            set { this.Right = (RedBlackNode<T>)value; }
        }

        /// <summary>
        /// Returns true if this node has no neighbours
        /// </summary>
        internal bool IsLeaf
        {
            get { return (this.Left == null && this.Right == null); }
        }

        /// <summary>
        /// Returns true if this node has no neighbours
        /// </summary>
        bool IInternalBinaryNode<T>.IsLeaf
        {
            get { return this.IsLeaf; }
        }

        private int _height;

        /// <summary>
        /// The height of the node.
        /// 
        /// O(1) - When cached
        /// O(log n) - Otherwise
        /// </summary>
        int IInternalBinaryNode<T>.Height
        {
            get
            {
                if (this._height == int.MinValue)
                    this._height = BinaryNodeCommon.GetNodeHeight(this);

                return this._height;
            }
        }

        /// <summary>
        /// The balance of the node. Node.Balance = Node.Left.Height - Node.Right.Height
        /// 
        /// O(log n) when one or more heights below this one aren't cached
        /// O(1) otherwise
        /// </summary>
        int IInternalBinaryNode<T>.Balance
        {
            get
            {
                return BinaryNodeCommon.GetNodeBalance(this);
            }
        }

        internal RedBlackNode<T> InOrderPredecessor
        {
            get { return BinaryNodeCommon.InOrderPredecessor(this) as RedBlackNode<T>; }
        }

        IInternalBinaryNode<T> IInternalBinaryNode<T>.InOrderPredecessor
        {
            get { return BinaryNodeCommon.InOrderPredecessor(this); }
        }

        IInternalBinaryNode<T> IInternalBinaryNode<T>.InOrderSuccessor
        {
            get { return BinaryNodeCommon.InOrderSuccessor(this); }
        }
        
        #endregion

        #region Rotations

        /// <summary>
        /// Rotates the tree rooted at this node in a counter-clockwise manner and recolours the root and pivot nodes accordingly.
        /// </summary>
        /// <returns>The new root of the tree</returns>
        internal RedBlackNode<T> RotateLeft()
        {
            RedBlackNode<T> pivot = this.Right;

            this.Right = pivot.Left;
            pivot.Left = this;

            //fix heights
            pivot.ResetHeight();
            this.ResetHeight();

            pivot.Left.Colour = Colour.Red;
            pivot.Colour = Colour.Black;

            return pivot;
        }

        /// <summary>
        /// Rotates the tree rooted at this node in a counter-clockwise manner and recolours the root and pivot nodes accordingly.
        /// </summary>
        /// <returns>The new root of the tree</returns>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.RotateLeft()
        {
            return this.RotateLeft();
        }

        /// <summary>
        /// Rotates the tree rooted at this node in a clockwise manner and recolours the root and pivot nodes accordingly.
        /// </summary>
        /// <returns>The new root of the tree</returns>
        internal RedBlackNode<T> RotateRight()
        {
            RedBlackNode<T> pivot = this.Left;

            this.Left = pivot.Right;
            pivot.Right = this;

            //fix heights
            pivot.ResetHeight();
            this.ResetHeight();

            pivot.Right.Colour = Colour.Red;
            pivot.Colour = Colour.Black;
            return pivot;
        }

        /// <summary>
        /// Rotates the tree rooted at this node in a counter-clockwise manner and recolours the root and pivot nodes accordingly.
        /// </summary>
        /// <returns>The new root of the tree</returns>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.RotateRight()
        {
            return this.RotateRight();
        }

        #endregion

        #region Methods

        internal void ResetHeight()
        {
            this._height = int.MinValue;
        }

        void IInternalBinaryNode<T>.ResetHeight()
        {
            this._height = int.MinValue;
        }

        public override string ToString()
        {
            string format = "{0},{1}; Left={2}; Right={3}";

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

            return string.Format(format, this.Value.ToString(), this.Colour.ToString(), left, right);
        }

        #endregion
    }
}
