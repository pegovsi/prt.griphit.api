using System;

namespace Prt.Graphit.Domain.Exceptions
{
    public class SkuDomainException : Exception
    {
        public SkuDomainException()
        {
        }

        public SkuDomainException(string message)
            : base(message)
        {
        }

        public SkuDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
