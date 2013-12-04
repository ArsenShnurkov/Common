namespace Common.Collections.Generic
{
    using System.Collections.Generic;

    internal sealed class IterativeBinaryNode<T>
    {
        /// <summary>
        /// Creates a new instance of a Common.Collections.Generic.BinaryNode<T>
        /// </summary>
        /// <param name="value">The data value that this node will contain</param>
        internal IterativeBinaryNode(T value)
        {
            this.Value      = value;
        }

        #region Properties

        internal T Value { get; set; }

        internal IterativeBinaryNode<T> Left { get; set; }
        internal IterativeBinaryNode<T> Right { get; set; }


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
        /// The height of the node.
        /// 
        /// O(log n)
        /// </summary>
        internal int Height
        {
            get
            {
                Queue<IterativeBinaryNode<T>> nodes = new Queue<IterativeBinaryNode<T>>();
                nodes.Enqueue(this);

                int height = -1;
                int nodesAtCurrentLevel;

                IterativeBinaryNode<T> current;
                while (nodes.Count > 0)
                {
                    nodesAtCurrentLevel = nodes.Count;
                    for (int i = 0; i < nodesAtCurrentLevel; ++i)
                    {
                        if (i == 0)
                            ++height;

                        current = nodes.Dequeue();

                        if (current.Left != null)
                            nodes.Enqueue(current.Left);

                        if (current.Right != null)
                            nodes.Enqueue(current.Right);
                    }
                }

                return height;
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
            get
            {
                int balance;
                if (this.IsLeaf)
                    balance = 0;
                else if (this.Right == null)
                    balance = this.Left.Height + 1;
                else if (this.Left == null)
                    balance = -1 - this.Right.Height;
                else
                    balance = this.Left.Height - this.Right.Height;
                return balance;
            }
        }

        internal IterativeBinaryNode<T> InOrderPredecessor
        {
            get
            {
                IterativeBinaryNode<T> previous = null;
                IterativeBinaryNode<T> current = this.Left;
                while (current != null)
                {
                    previous = current;
                    current = current.Right;
                }

                return previous;
            }
        }

        internal IterativeBinaryNode<T> InOrderSuccessor
        {
            get
            {
                IterativeBinaryNode<T> previous = null;
                IterativeBinaryNode<T> current = this.Right;
                while (current != null)
                {
                    previous = current;
                    current = current.Left;
                }

                return previous;
            }
        }

        #endregion

        #region Methods
        
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