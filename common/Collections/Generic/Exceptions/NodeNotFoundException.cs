namespace Common.Collections.Generic
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NodeNotFoundException : Exception, ISerializable
    {
        public NodeNotFoundException() : base() { }
        public NodeNotFoundException(string message) : base(message) { }
        public NodeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
