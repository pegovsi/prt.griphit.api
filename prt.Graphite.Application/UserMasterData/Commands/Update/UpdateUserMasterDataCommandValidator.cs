using FluentValidation;

namespace Prt.Graphit.Application.UserMasterData.Commands.Update
{
    public class UpdateUserMasterDataCommandValidator
        : AbstractValidator<UpdateUserMasterDataCommand>
    {
        public UpdateUserMasterDataCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.UserMasterDataId).NotEmpty();
            RuleFor(x => x.UserMasterDataFields).NotNull();
        }
    }
}
