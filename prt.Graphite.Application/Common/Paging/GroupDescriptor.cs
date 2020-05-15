﻿namespace Prt.Graphit.Application.Common.Paging
{
    public class GroupDescriptor
    {
        public GroupDescriptor(
            string field, EnumSortDirection direction = EnumSortDirection.ASC, bool isExpanded = false)
        {
            Field = field;
            Direction = direction;
            IsExpanded = isExpanded;
        }

        public string Field { get; }

        public EnumSortDirection Direction { get; }

        public bool IsExpanded { get; }

        public override string ToString()
            => string.Concat(Field, " ", Direction.ToString(), " ", IsExpanded.ToString());
    }
}
