using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Commands.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateVehicleCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (vehicle is null)
            {
                var condition = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Condition>()
                .FirstOrDefaultAsync(x => x.Name == request.ConditionId, cancellationToken);

                vehicle = new Domain.AggregatesModel.Vehicle.Entities.Vehicle
                (
                    id: request.Id,
                    name: request.Name,
                    vehicleTypeId: request.VehicleTypeId,
                    chassiId: request.ChassiId,
                    vehicleModelId: request.VehicleModelId,
                    vehicleNomberFactory: request.VehicleNomberRegister,
                    vehicleNomberRegister: request.VehicleNomberRegister,
                    vehicleNomberChassis: request.VehicleNomberChassis,
                    manufacturerId: request.ManufacturerId,
                    yearOfIssue: request.YearOfIssue,
                    garrisonId: request.GarrisonId,
                    cityId: request.CityId,
                    divisionId: request.DivisionId,
                    subdivisionId: request.SubdivisionId,
                    brigadeId: request.BrigadeId,
                    isApproved: request.IsApproved,
                    mileage: request.Mileage,
                    shotsAmoun: request.ShotsAmount,
                    operatingTime: request.OperatingTime,
                    conditionId: condition?.Id,
                    responsible: request.Responsible,
                    readoutDate: request.ReadoutDate,
                    startupDate: request.ReadoutDate
                );
                await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                    .AddAsync(vehicle, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return ResultHelper.Success(true);
        }
    }
}
