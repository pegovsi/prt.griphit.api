using AutoMapper;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.UserMasterData.Commands.Create
{
    public class CreateUserMasterDataCommandHandler
        : HandlerQueryBase<CreateUserMasterDataCommand, Result<Guid>>
    {
        public CreateUserMasterDataCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(CreateUserMasterDataCommand request,
            CancellationToken cancellationToken)
        {
            var userMasterData = new Domain.AggregatesModel.UserMasterData.Entities.UserMasterData
            (
                name: request.Name,
                vehicleModelId: request.VehicleModelId
            );
            foreach (var field in request.UserMasterDataFields)
            {
                userMasterData.AddField(field.Name, field.TypeUserMasterDataId);
            }

            await ContextDb.Set<Domain.AggregatesModel.UserMasterData.Entities.UserMasterData>()
                .AddAsync(userMasterData, cancellationToken);
            await ContextDb.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(userMasterData.Id);
        }
    }
}
