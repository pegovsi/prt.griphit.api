using MediatR;
using Prt.Graphit.Application.UserMasterData.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataByVehicleModelId
{
    public class GetUserMasterDataByVehicleModelIdQuery
        :IRequest<UserMasterDataDto[]>
    {
        public Guid VehicleModelId { get; }

        public GetUserMasterDataByVehicleModelIdQuery(Guid vehicleModelId)
        {
            VehicleModelId = vehicleModelId;
        }
    }
}
