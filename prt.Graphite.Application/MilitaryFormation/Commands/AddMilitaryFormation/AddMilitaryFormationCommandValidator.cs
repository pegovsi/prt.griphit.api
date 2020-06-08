using FluentValidation;

namespace Prt.Graphit.Application.MilitaryFormation.Commands.AddMilitaryFormation
{
    public class AddMilitaryFormationCommandValidator :
        AbstractValidator<AddMilitaryFormationCommand>
    {
        public AddMilitaryFormationCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ShortName).NotEmpty();
        }
    }
}
