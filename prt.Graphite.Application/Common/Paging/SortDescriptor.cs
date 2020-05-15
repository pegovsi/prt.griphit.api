namespace Prt.Graphit.Application.Common.Paging
{
    public class SortDescriptor
    {
        public SortDescriptor(string field, EnumSortDirection direction = EnumSortDirection.ASC)
        {
            Field = field;
            Direction = direction;
        }

        public string Field { get; set; }

        public EnumSortDirection Direction { get; set; }

        public override string ToString()
        {
            var direction = string.Empty;

            if (Direction == EnumSortDirection.DESC)
            {
                direction = $" {Direction.ToString()}";
            }

            return $"{Field}{direction}";
        }
    }
}
