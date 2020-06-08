using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prt.Graphit.Domain.Enumerations
{
    public class ActiveStatus : Enumeration
    {
        public static ActiveStatus Active = new ActiveStatus(1, nameof(Active).ToLowerInvariant());
        public static ActiveStatus Inactive = new ActiveStatus(2, nameof(Inactive).ToLowerInvariant());
        public static ActiveStatus Draft = new ActiveStatus(3, nameof(Draft).ToLowerInvariant());

        public ActiveStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<ActiveStatus> List() =>
            new[] { Active, Inactive, Draft };

        public static ActiveStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ActiveStatusException($"Possible values for {nameof(ActiveStatus)}: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ActiveStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ActiveStatusException($"Possible values for {nameof(ActiveStatus)}: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
