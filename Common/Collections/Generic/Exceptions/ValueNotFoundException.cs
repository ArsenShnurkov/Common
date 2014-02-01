namespace Common.Collections.Generic
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ValueNotFoundException : Exception, ISerializable
    {
        public ValueNotFoundException() : base() { }
        public ValueNotFoundException(string message) : base(message) { }
        public ValueNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
