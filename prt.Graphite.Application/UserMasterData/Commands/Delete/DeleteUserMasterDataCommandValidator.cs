using FluentValidation;
using System;

namespace Prt.Graphit.Application.UserMasterData.Commands.Delete
{
    public class DeleteUserMasterDataCommandValidator
        : AbstractValidator<DeleteUserMasterDataCommand>
    {
        public DeleteUserMasterDataCommandValidator()
        {
            RuleFor(x => x.UserMasterDataId)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .NotNull();
        }
    }
}
