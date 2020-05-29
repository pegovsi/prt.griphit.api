using MediatR;
using Prt.Graphit.Application.Sku.Models;

namespace Prt.Graphit.Application.Sku.Queries.SearchSkuByName
{
    public class SearchSkuByNameQuery : IRequest<SkuDto[]>
    {
        public string SkuNameSearch { get; }

        public SearchSkuByNameQuery(string skuNameSearch)
        {
            SkuNameSearch = skuNameSearch;
        }
    }
}
