using System.Runtime.CompilerServices;
namespace Common.Collections.Generic
{
    internal sealed class RedBlackNode<T>
    {
        internal RedBlackNode(T value)
        {
            this.Left = null;
            this.Right = null;
            this._height = int.MinValue;
            this.Value = value;
            this._isRed = true;
        }

        internal RedBlackNode(T value, Colour colour)
        {
            this.Left = null;
            this.Right = null;
            this._height = int.MinValue;
            this.Value = value;
            this.SetColour(colour);
        }

        #region Properties

        internal T Value { get; set; }

        /// <summary>
        /// Points to a the left sub tree of this node
        /// </summary>
        internal RedBlackNode<T> Left { get; set; }

        /// <summary>
        /// Points to a the right sub tree of this node
        /// </summary>
        internal RedBlackNode<T> Right { get; set; }

        /// <summary>
        /// The colour of the node.
        /// </summary>
        private bool _isRed;

        /// <summary>
        /// Returns true if the node is red, returns false if the node is black.
        /// </summary>
        internal bool IsRed
        {
            get { return this._isRed; }
        }

        /// <summary>
        /// Returns true if this node has no neighbours
        /// </summary>
        internal bool IsLeaf
        {
            get { return (this.Left == null && this.Right == null); }
        }

        private int _height;

        /// <summary>
        /// The height of the node.
        /// 
        /// O(1) - When cached
        /// O(log n) - Otherwise
        /// </summary>
        internal int Height
        {
            get
            {
                if (this._height == int.MinValue)
                {
                    this._height = this.GetNodeHeight();
                }

                return this._height;
            }
        }

        /// <summary>
        /// The balance of the node. Node.Balance = Node.Left.Height - Node.Right.Height
        /// 
        /// O(log n) when one or more heights below this one aren't cached
        /// O(1) otherwise
        /// </summary>
        internal int Balance
        {
            get { return this.GetNodeBalance(); }
        }

        internal RedBlackNode<T> InOrderPredecessor
        {
            get
            {
                RedBlackNode<T> previous = null;
                RedBlackNode<T> current = this.Left;
                while (current != null)
                {
                    previous = current;
                    current = current.Right;
                }

                return previous;
            }
        }

        internal RedBlackNode<T> InOrderSuccessor
        {
            get
            {
                RedBlackNode<T> previous = null;
                RedBlackNode<T> current = this.Right;
                while (current != null)
                {
                    previous = current;
                    current = current.Left;
                }

                return previous;
            }
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

            pivot.Left.SetColour(Colour.Red);
            pivot.SetColour(Colour.Black);

            return pivot;
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

            pivot.Right.SetColour(Colour.Red);
            pivot.SetColour(Colour.Black);

            return pivot;
        }

        #endregion

        #region Height and Balance Helper Methods

        /// <summary>
        /// Returns the height of a node that is potentially null
        /// </summary>
        /// <typeparam name="T">The data type contained within the node</typeparam>
        /// <param name="node">The child node that we want the height for</param>
        /// <returns>-1 if the node is null. Otherwise it returns the cached node height</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetChildNodeHeight(RedBlackNode<T> node)
        {
            return (node == null) ? -1 : node.Height;
        }

        /// <summary>
        /// Retrieves the height of the node calculated as Height = Max(Left.Height, Right.Height) + 1
        /// 
        /// The height of a tree that only has a root is 0
        /// </summary>
        /// <typeparam name="T">The data type contained within the node</typeparam>
        /// <param name="node">The node who's height needs to be calculated</param>
        internal int GetNodeHeight()
        {
            return System.Math.Max(GetChildNodeHeight(this.Left), GetChildNodeHeight(this.Right)) + 1;
        }

        /// <summary>
        /// Retrieves the balance of a node calculated as node.Balance = Node.Left.Balance - Node.Right.Balance
        /// </summary>
        internal int GetNodeBalance()
        {
            return GetChildNodeHeight(this.Left) - GetChildNodeHeight(this.Right);
        }

        #endregion

        #region Methods

        internal void SetIsRed(bool isRed)
        {
            this._isRed = isRed;
        }

        internal void SetColour(Colour colour)
        {
            this._isRed = colour == Colour.Red;
        }

        internal void ResetHeight()
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

            return string.Format(format, this.Value.ToString(), this.IsRed?"Red":"Black", left, right);
        }

        #endregion
    }
}
