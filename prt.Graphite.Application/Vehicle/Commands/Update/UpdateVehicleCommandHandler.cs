using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Exceptions;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;

namespace Prt.Graphit.Application.Vehicle.Commands.Update
{
    public class UpdateVehicleCommandHandler : HandlerQueryBase<UpdateVehicleCommand, Result<Guid>>
    {
        public UpdateVehicleCommandHandler(IAppDbContext appDbContext, IMapper mapper) 
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .Include(x=>x.UserMasterDataValues)
                .FirstOrDefaultAsync(x => x.Id == request.VehicleId, cancellationToken);
            if(vehicle is null)
                throw new NotFoundException($"Не найдет экземпляр с id {request.VehicleId}");
            
            vehicle.SetFactoryNumber(request.FactoryNumber);
            vehicle.SetChassis(request.Chassis);

            foreach (var field in request.Fields)
            {
                vehicle.AddUserMasterDataValue
                (
                    field.UserMasterDataId,
                    field.UserMasterDataFieldId,
                    vehicle.Id,
                    field.Value
                );   
            }

            ContextDb.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .Update(vehicle);
            await ContextDb.SaveChangesAsync(cancellationToken);
            
            return ResultHelper.Success(request.VehicleId);
        }
    }
}