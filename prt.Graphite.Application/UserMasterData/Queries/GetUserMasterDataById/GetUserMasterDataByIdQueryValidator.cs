using FluentValidation;

namespace Prt.Graphit.Application.UserMasterData.Queries.GetUserMasterDataById
{
    public class GetUserMasterDataByIdQueryValidator
        : AbstractValidator<GetUserMasterDataByIdQuery>
    {
        public GetUserMasterDataByIdQueryValidator()
        {
            RuleFor(x => x.UserMasterDataId).NotEmpty();
        }
    }
}
