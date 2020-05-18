using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Sku.Commands.CreateSku
{
    public class CreateSkuCommandHandler : IRequestHandler<CreateSkuCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateSkuCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(CreateSkuCommand request, CancellationToken cancellationToken)
        {
            if (request.SkuGroup != null)
            {
                var group = await _appDbContext.Set<Domain.AggregatesModel.Sku.Entities.SkuGroup>()
                    .FirstOrDefaultAsync(x => x.Id == request.SkuGroup.Id, cancellationToken);

                if (group is null)
                {
                    var skugroup = new Domain.AggregatesModel.Sku.Entities.SkuGroup
                    (
                        id: request.SkuGroup.Id,
                        name: request.SkuGroup.Name,
                        parentId: request.SkuGroup.ParentId
                    );
                    await _appDbContext.Set<Domain.AggregatesModel.Sku.Entities.SkuGroup>()
                        .AddAsync(skugroup);
                    await _appDbContext.SaveChangesAsync(cancellationToken);
                }
            }
/////////////////////////////////////////////////////////////////////////////////////////////////
            var type = await _appDbContext.Set<Domain.AggregatesModel.Sku.Entities.SkuType>()
                .FirstOrDefaultAsync(x => x.Id == request.SkuType.Id, cancellationToken);
            if (type is null)
            {
                var skutype = new Domain.AggregatesModel.Sku.Entities.SkuType
                (
                    id: request.SkuType.Id,
                    name: request.SkuType.Name
                );
                await _appDbContext.Set<Domain.AggregatesModel.Sku.Entities.SkuType>()
                    .AddAsync(skutype);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            var sku = await _appDbContext.Set<Domain.AggregatesModel.Sku.Entities.Sku>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(sku != null)
                return ResultHelper.Success(true);

            sku = new Domain.AggregatesModel.Sku.Entities.Sku
            (
                id: request.Id,
                name: request.Name,
                parentId: request.ParentId,
                skuGroupId: request.SkuGroup?.Id,
                skuTypeId: request.SkuType.Id,
                designation: request.Designation,
                description: request.Description
            );

            foreach (var unit in request.Units)
            {
                sku.AddUnit(unit.Name, unit.Coefficient, unit.Base);
            }

            await _appDbContext.Set<Domain.AggregatesModel.Sku.Entities.Sku>().AddAsync(sku, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return ResultHelper.Success(true);
        }
    }
}
