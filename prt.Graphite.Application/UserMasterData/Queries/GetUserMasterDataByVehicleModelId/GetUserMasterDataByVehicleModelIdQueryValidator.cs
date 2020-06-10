using FluentValidation;
using System;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataByVehicleModelId
{
    public class GetUserMasterDataByVehicleModelIdQueryValidator
        : AbstractValidator<GetUserMasterDataByVehicleModelIdQuery>
    {
        public GetUserMasterDataByVehicleModelIdQueryValidator()
        {
            RuleFor(x => x.VehicleModelId)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
