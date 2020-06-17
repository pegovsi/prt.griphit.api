using FluentValidation;

namespace Prt.Graphit.Application.VehicleModel.Queries.GetVehicleModelPositionsByVehicleId
{
    public class GetVehicleModelPositionsByVehicleIdQueryValidator
    : AbstractValidator<GetVehicleModelPositionsByVehicleIdQuery>
    {
        public GetVehicleModelPositionsByVehicleIdQueryValidator()
        {
            RuleFor(x => x.VehicleId).NotEmpty();
        }
    }
}