namespace Common.Collections.Generic
{

    internal sealed class SkipListNode<T>
    {
        internal SkipListNode(int levels, T value)
        {
            this.Value = value;
            this.Next = new SkipListNode<T>[levels];
        }

        #region Properties

        internal T Value { get; set; }
        internal SkipListNode<T>[] Next { get; set; }
        internal int Levels { get { return this.Next.Length; } }

        #endregion
    }
}
