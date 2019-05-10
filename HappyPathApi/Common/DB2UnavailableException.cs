using System;
using System.Runtime.Serialization;

namespace HappyPathApi.Common
{
    public class DB2UnavailableException : Exception
    {
        public DB2UnavailableException()
        {
        }

        public DB2UnavailableException(string message) : base(message)
        {
        }

        public DB2UnavailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DB2UnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
