namespace Common.Collections.Generic
{
    using System;

    public sealed partial class SkipList<T> where T : IComparable<T>
    {
        #region Constructors

        public SkipList()
        {
            this.Random = new Random();
            InitParameters();
        }

        private void InitParameters()
        {

            this.Count = 0;
            this.Levels = 1;
            this.Head = new SkipListNode<T>(32, default(T));
        }

        #endregion

        #region Properties

        private Random Random;
        internal SkipListNode<T> Head { get; set; }

        /// <summary>
        /// Returns the number of items in the skip list
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns the maximum allowed level of a node. This number is based off of the Count of the skip list.
        /// </summary>
        public int MaxLevels
        {
            get
            {
                if (this.Count == 0)
                    return 1;
                else
                    return Math.Min((int)Math.Log(this.Count, 2) + 1, 32);
            }
        }

        /// <summary>
        /// Returns the height of node with the most levels within the skip list.
        /// </summary>
        public int Levels { get; set; }

        #endregion

        #region Insert

        internal int RandomNumber()
        {
            return this.Random.Next();
        }

        /// <summary>
        /// Calculates a random level. Used when creating a new skip list node
        /// </summary>
        /// <returns>A random number between 1 and MaxLevel</returns>
        internal int RandomLevel()
        {
            int level = 1;
            int maxLevels = this.MaxLevels;
            while (this.RandomNumber() % 2 == 0 && level < maxLevels)
                ++level;

            return level;
        }

        /// <summary>
        /// Creates a new SkipListNode with a level that is smaller than or equal to the MaxLevel of the skip list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal SkipListNode<T> CreateSkipListNode(T value)
        {
            return new SkipListNode<T>(this.RandomLevel(), value);
        }

        /// <summary>
        /// Inserts a new value into the skip list.
        /// </summary>
        public void Insert(T value)
        {
            this.Insert(this.CreateSkipListNode(value));
        }

        /// <summary>
        /// Inserts the given node into the skip list.
        /// </summary>
        internal void Insert(SkipListNode<T> node)
        {
            SkipListNode<T>[] previousNodes = new SkipListNode<T>[this.MaxLevels];
            SkipListNode<T> previous = this.Head;

            // find the insertion point, making use of the highest / most sparse levels first
            for (int level = this.Levels-1; level >= 0; --level)
            {
                while (previous.Next[level] != null && previous.Next[level].Value.CompareTo(node.Value) < 0)
                    previous = previous.Next[level];

                if (level <= node.Levels)
                    previousNodes[level] = previous;
            }

            // Increase the skip list's level if necessary
            while (this.Levels < node.Levels)
            {
                ++this.Levels;
                previousNodes[this.Levels-1] = this.Head;
            }

            // Update all of the levels in the skip list to point to the new node
            for (int curLevel = 0; curLevel < node.Levels; ++curLevel)
            {
                node.Next[curLevel] = previousNodes[curLevel].Next[curLevel];
                previousNodes[curLevel].Next[curLevel] = node;
            }

            ++this.Count;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Returns true if the value has been found in the skip list.
        /// </summary>
        public bool Contains(T value)
        {
            if (this.Find(value) != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Finds the node with the given value within the skip list.
        /// </summary>
        /// <returns>The node with the given value, or null if no node exists.</returns>
        internal SkipListNode<T> Find(T value)
        {
            SkipListNode<T> current = this.Head;
            for (int level = this.Levels - 1; level >= 0; --level)
            {
                while (current.Next[level] != null && current.Next[level].Value.CompareTo(value) <= 0)
                    current = current.Next[level];
            }

            if (current != null && current.Value.CompareTo(value) == 0)
                return current;
            else
                return null;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Removes the node with the given value from the list.
        /// </summary>
        /// <returns>Returns true if a node was deleted.</returns>
        public bool Delete(T value)
        {
            bool deleted = false;
            SkipListNode<T>[] previousNodes = new SkipListNode<T>[this.Levels];
            SkipListNode<T> node = this.Head;

            for (int level = this.Levels - 1; level >= 0; --level)
            {
                while (node.Next[level] != null && node.Next[level].Value.CompareTo(value) < 0)
                    node = node.Next[level];

                if (node.Next[level] != null)
                    previousNodes[level] = node;
            }

            node = node.Next[0];

            if (node.Value.CompareTo(value) == 0)
            {
                for (int level = 0; level < node.Levels; ++level)
                {
                    deleted = true;
                    SkipListNode<T> toDelete = previousNodes[level].Next[level];
                    previousNodes[level].Next[level] = toDelete.Next[level];
                    toDelete.Next[level] = null;
                }
            }

            --this.Count;
            return deleted;
        }

        #endregion

    }
}
