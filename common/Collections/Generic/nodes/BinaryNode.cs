namespace Common.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public class BinaryNode<T> : INode<T>, IBinaryNode<T>
    {
        /// <summary>
        /// Creates a new instance of a Common.Collections.Generic.BinaryNode<T>
        /// </summary>
        /// <param name="value">The data value that this node will contain</param>
        public BinaryNode(T value)
        {
            this._height = 0;
            this.Value = value;
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
        /// Returns the in order predecessor of this node if one exists or null otherwise
        /// </summary>
        internal BinaryNode<T> InOrderPredecessor
        {
            get
            {
                BinaryNode<T> previous = null;
                BinaryNode<T> current = this.Left;
                while (current != null)
                {
                    previous = current;
                    current = current.Right;
                }

                return previous;
            }
        }

        /// <summary>
        /// Returns the in order successor of this node if one exists or null otherwise
        /// </summary>
        internal BinaryNode<T> InOrderSuccessor
        {
            get
            {
                BinaryNode<T> previous = null;
                BinaryNode<T> current = this.Right;
                while (current != null)
                {
                    previous = current;
                    current = current.Left;
                }

                return previous;
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

        /// <summary>
        /// Returns an enumerable list of neighbouring ndoes
        /// </summary>
        public IEnumerable<INode<T>> Neighbours
        {
            get { return new IBinaryNode<T>[2] { this.Left, this.Right }; }
        }

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
                    if (this.IsLeaf)
                        this._height = 0;
                    else if (this.Right == null)
                        this._height = this.Left.Height + 1;
                    else if (this.Left == null)
                        this._height = this.Right.Height + 1;
                    else
                        this._height = Math.Max(this.Left.Height, this.Right.Height) + 1;
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
                if (this.IsLeaf)
                    return 0;
                else if (this.Right == null)
                    return this.Left.Height + 1;
                else if (this.Left == null)
                    return -1 - this.Right.Height;
                else
                    return this.Left.Height - this.Right.Height;
            }
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
            string format = "Value = {0}; Left={1}; Right={2}";

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

        #region Rotations

        /// <summary>
        /// Rotates a tree around R                     Resulting in
        /// 
        ///        R                                        B
        ///       / \                                      / \
        ///      A    B                                   R   F
        ///     / \  / \                                 / \
        ///    C   D E  F                               A   E
        ///                                            / \    
        ///                                           C   D
        ///                                           
        /// In this implementation the root node doesn't actually move. We only swap the
        /// value out so it seems to move. This prevents us from having re-root the tree
        /// after the rotation
        /// </summary>
        internal void RotateLeft()
        {
            BinaryNode<T> pivot = this.Right;

            //move child pointers
            T temp = pivot.Value;
            pivot.Value = this.Value;
            this.Value = temp;

            this.Right = pivot.Right;
            pivot.Right = pivot.Left;
            pivot.Left = this.Left;
            this.Left = pivot;

            //fix heights
            pivot.ResetHeight();
            this.ResetHeight();
        }

        /// <summary>
        /// Rotates a tree around R                    Resulting in
        /// 
        ///        R                                        A
        ///       / \                                      / \
        ///      A    B                                   C   R
        ///     / \  / \                                     / \
        ///     C  D E  F                                   D   B
        ///                                                    / \          
        ///                                                   E   F
        ///             
        /// In this implementation the root node doesn't actually move. We only swap the
        /// value out so it seems to move. This prevents us from having re-root the tree
        /// after the rotation
        /// </summary>
        internal void RotateRight()
        {
            BinaryNode<T> pivot = this.Left;

            //move child pointers
            T temp = pivot.Value;
            pivot.Value = this.Value;
            this.Value = temp;

            this.Left = pivot.Left;
            pivot.Left = pivot.Right;
            pivot.Right = this.Right;
            this.Right = pivot;

            //fix heights
            pivot.ResetHeight();
            this.ResetHeight();
        }

        #endregion

    }
}