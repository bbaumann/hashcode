namespace hashcode.tools.timemanagement
{
    [System.Serializable]
    public class TimeoutException : System.Exception
    {
        public TimeoutException() { }
        public TimeoutException(string message) : base(message) { }
        public TimeoutException(string message, System.Exception inner) : base(message, inner) { }
        protected TimeoutException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}