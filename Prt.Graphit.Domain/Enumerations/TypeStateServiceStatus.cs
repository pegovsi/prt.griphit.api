using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prt.Graphit.Domain.Enumerations
{
    /// <summary>
    /// Вид государственной службы
    /// </summary>
    public class TypeStateServiceStatus : Enumeration
    {
        /// <summary>
        /// Военный
        /// </summary>
        public static TypeStateServiceStatus Military = new TypeStateServiceStatus(1, nameof(Military).ToLowerInvariant());
        /// <summary>
        /// Гражданский
        /// </summary>
        public static TypeStateServiceStatus Civil = new TypeStateServiceStatus(2, nameof(Civil).ToLowerInvariant());

        public TypeStateServiceStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<TypeStateServiceStatus> List() =>
            new[] { Military, Civil };

        public static TypeStateServiceStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new TypeStateServiceException($"Possible values for {nameof(ActiveStatus)}: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static TypeStateServiceStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new TypeStateServiceException($"Possible values for {nameof(ActiveStatus)}: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
