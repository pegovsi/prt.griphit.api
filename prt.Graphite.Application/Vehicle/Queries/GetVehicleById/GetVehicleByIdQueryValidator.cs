using FluentValidation;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryValidator : AbstractValidator<GetVehicleByIdQuery>
    {
        public GetVehicleByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
