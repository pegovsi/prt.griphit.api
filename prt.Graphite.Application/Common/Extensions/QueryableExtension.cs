using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Common.Extensions;
using System;
using System.Linq;

namespace Prt.Graphit.Application.Common.Extensions
{
    public static class QueryableExtension
    {
        public static Tuple<IQueryable<TM>, int> ApplySorting<TM, TF>(this IQueryable<TM> model, IPageContext<TF> pageContext)
        {
            var totalCount = model.Count();

            if (pageContext != null)
            {
                if (pageContext.ListSort != null)
                {
                    foreach (var sortDescriptor in pageContext.ListSort)
                    {
                        if (!string.IsNullOrEmpty(sortDescriptor.Field) &&
                            model.PropertyExists(sortDescriptor.Field))
                        {
                            model = sortDescriptor.Direction ==
                                    EnumSortDirection.ASC
                                ? model.OrderByProperty(sortDescriptor.Field)
                                : model.OrderByPropertyDescending(sortDescriptor.Field);
                        }
                    }
                }

                if (pageContext.PageIndex != 0 && pageContext.PageSize != 0)
                {
                    model = model.Skip((pageContext.PageIndex - 1) * pageContext.PageSize)
                        .Take(pageContext.PageSize);
                }
            }

            return Tuple.Create(model, totalCount);
        }
    }
}
