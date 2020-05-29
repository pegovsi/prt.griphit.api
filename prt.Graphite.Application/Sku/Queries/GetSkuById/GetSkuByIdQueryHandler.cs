using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Sku.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Sku.Queries
{
    public class GetSkuByIdQueryHandler : HandlerQueryBase<GetSkuByIdQuery, SkuDto>
    {
        public GetSkuByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public async override Task<SkuDto> Handle(GetSkuByIdQuery request, CancellationToken cancellationToken)
        {
            var sku = await ContextDb.Set<Domain.AggregatesModel.Sku.Entities.Sku>()
                .Include(x=>x.SkuGroup)
                .Include(x => x.SkuType)
                .Include(x => x.Units)
                .FirstOrDefaultAsync(x => x.Id == request.SkuId, cancellationToken: cancellationToken);

            return AutoMapper.Map<SkuDto>(sku);
        }
    }
}
