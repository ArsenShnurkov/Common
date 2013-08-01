namespace Common.Collections.Generic
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TreeNotRootedException : NullReferenceException, ISerializable
    {
        public TreeNotRootedException() : base() { }
        public TreeNotRootedException(string message) : base(message) { }
        public TreeNotRootedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
