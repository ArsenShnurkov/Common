namespace Common.Collections.Generic
{
    internal class BinaryNode<T> : IInternalBinaryNode<T>
    {
        /// <summary>
        /// Creates a new instance of a Common.Collections.Generic.BinaryNode<T>
        /// </summary>
        /// <param name="value">The data value that this node will contain</param>
        internal BinaryNode(T value)
        {
            this.Left      = null;
            this.Right     = null;
            this._height    = int.MinValue;
            this.Value     = value;
        }

        #region Properties

        internal T Value { get; set; }
        T IInternalBinaryNode<T>.Value
        {
            get { return this.Value; }
            set { this.Value = value; }
        }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        internal BinaryNode<T> Left { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.Left
        {
            get { return this.Left; }
            set { this.Left = (BinaryNode<T>)value; }
        }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        internal BinaryNode<T> Right { get; set; }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        IInternalBinaryNode<T> IInternalBinaryNode<T>.Right
        {
            get { return this.Right; }
            set { this.Right = (BinaryNode<T>)value; }
        }

        /// <summary>
        /// Returns true if this node has no neighbours
        /// </summary>
        internal bool IsLeaf
        {
            get
            {
                return (this.Left == null && this.Right == null);
            }
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
            get { return BinaryNodeCommon.GetNodeBalance(this); }
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
        IInternalBinaryNode<T> IInternalBinaryNode<T>.RotateLeft()
        {
            BinaryNode<T> pivot = this.Right;

            this.Right = pivot.Left;
            pivot.Left = this;

            //fix heights
            pivot.ResetHeight();
            this.ResetHeight();

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
        IInternalBinaryNode<T> IInternalBinaryNode<T>.RotateRight()
        {
            BinaryNode<T> pivot = this.Left;

            this.Left = pivot.Right;
            pivot.Right = this;

            //fix heights
            pivot.ResetHeight();
            this.ResetHeight();

            return pivot;
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
            IInternalBinaryNode<T> iThis = this as IInternalBinaryNode<T>;

            string format = "{0}; Left={1}; Right={2}";

            string left;
            if (iThis.Left == null)
                left = "null";
            else
                left = iThis.Left.Value.ToString();

            string right;
            if (iThis.Right == null)
                right = "null";
            else
                right = iThis.Right.Value.ToString();

            return string.Format(format, iThis.Value.ToString(), left, right);
        }

        #endregion
    }
}