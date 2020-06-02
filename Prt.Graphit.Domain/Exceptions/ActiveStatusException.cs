using System;

namespace Prt.Graphit.Domain.Exceptions
{
    public class ActiveStatusException : Exception
    {
        public ActiveStatusException()
        {
        }

        public ActiveStatusException(string message)
            : base(message)
        {
        }

        public ActiveStatusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
