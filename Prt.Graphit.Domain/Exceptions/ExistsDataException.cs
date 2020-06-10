using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Domain.Exceptions
{
    /// <summary>
    /// Объект уже существует
    /// </summary>
    public class ExistsDataException : Exception
    {
        public ExistsDataException(string message)
           : base(message)
        {
        }
    }
}
