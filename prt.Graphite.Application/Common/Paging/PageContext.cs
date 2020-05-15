using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Common.Paging
{
    public class PageContext<T> : IPageContext<T>
         where T : class, new()
    {
        public PageContext(
            int pageIndex,
            int pageSize,
            IEnumerable<SortDescriptor> listSort = null,
            IEnumerable<GroupDescriptor> listGroup = null,
            T filter = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Filter = filter ?? new T();
            ListSort = listSort;
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public T Filter { get; set; }

        public IEnumerable<SortDescriptor> ListSort { get; set; }

        public bool IsValid()
        {
            return PageIndex > 0 && PageSize > 0;
        }
    }
}
