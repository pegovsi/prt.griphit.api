using FluentValidation;

namespace Prt.Graphit.Application.Sku.Queries
{
    public class GetSkuByIdQueryValidator : AbstractValidator<GetSkuByIdQuery>
    {
        public GetSkuByIdQueryValidator()
        {
            RuleFor(x => x.SkuId).NotNull().NotEmpty();
        }
    }
}