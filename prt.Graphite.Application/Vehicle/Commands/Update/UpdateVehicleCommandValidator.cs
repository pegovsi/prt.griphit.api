using FluentValidation;

namespace Prt.Graphit.Application.Vehicle.Commands.Update
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
        {
            RuleFor(x => x.VehicleId).NotEmpty();
            RuleFor(x => x.FactoryNumber).NotEmpty();
        }
    }
}