using FluentValidation;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleImage
{
    public class GetVehicleImageQueryValidator : AbstractValidator<GetVehicleImageQuery>
    {
        public GetVehicleImageQueryValidator()
        {
            RuleFor(x => x.FileName).NotEmpty();
            RuleFor(x => x.VehicleId).NotEmpty();
        }
    }
}
