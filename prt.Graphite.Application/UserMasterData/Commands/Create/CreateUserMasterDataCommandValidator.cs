using FluentValidation;

namespace Prt.Graphit.Application.UserMasterData.Commands.Create
{
    public class CreateUserMasterDataCommandValidator
        : AbstractValidator<CreateUserMasterDataCommand>
    {
        public CreateUserMasterDataCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.VehicleModelId).NotEmpty();
            RuleFor(x => x.UserMasterDataFields).NotNull();
        }
    }
}
