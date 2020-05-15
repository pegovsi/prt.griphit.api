using System.Collections.Generic;

namespace Prt.Graphit.Application.Common.Paging
{
    public interface IPageContext<T>
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }

        T Filter { get; set; }

        IEnumerable<SortDescriptor> ListSort { get; set; }

        bool IsValid();
    }
}
