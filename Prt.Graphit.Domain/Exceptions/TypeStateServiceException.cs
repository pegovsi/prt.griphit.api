using System;

namespace Prt.Graphit.Domain.Exceptions
{
    public class TypeStateServiceException : Exception
    {
        public TypeStateServiceException()
        {
        }

        public TypeStateServiceException(string message)
            : base(message)
        {
        }

        public TypeStateServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
