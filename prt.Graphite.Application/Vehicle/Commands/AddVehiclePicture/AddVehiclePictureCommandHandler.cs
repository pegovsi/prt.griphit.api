using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Commands.AddVehiclePicture
{
    public class AddVehiclePictureCommandHandler : IRequestHandler<AddVehiclePictureCommand, Result<bool>>
    {
        private readonly IAppDbContext _appDbContext;
        public AddVehiclePictureCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<bool>> Handle(AddVehiclePictureCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = await _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                .FirstOrDefaultAsync(x => x.Id == request.VehicleId, cancellationToken);
            if (vehicle is null)
                return ResultHelper.Error<bool>("Not fount");

            foreach (var item in request.Pictures)
            {
                vehicle.AddPicture(item.Uri, item.UriPreview);
            }

            _appDbContext.Set<Domain.AggregatesModel.Vehicle.Entities.Vehicle>()
                   .Update(vehicle);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success<bool>(true);
        }
    }
}