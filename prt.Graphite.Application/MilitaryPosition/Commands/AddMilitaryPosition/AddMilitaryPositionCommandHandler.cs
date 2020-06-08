using AutoMapper;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Domain.Enumerations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryPosition.Commands.AddMilitaryPosition
{
    public class AddMilitaryPositionCommandHandler :
        HandlerQueryBase<AddMilitaryPositionCommand, Result<Guid>>
    {
        public AddMilitaryPositionCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(AddMilitaryPositionCommand request, CancellationToken cancellationToken)
        {
            var militaryPosition = new Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition
            (
                name: request.Name,
                shortName: request.ShortName,
                typeStateServiceStatus: TypeStateServiceStatus.Military
            );

            await ContextDb.Set<Domain.AggregatesModel.MilitaryPosition.Entities.MilitaryPosition>()
                .AddAsync(militaryPosition, cancellationToken);

            await ContextDb.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success(militaryPosition.Id);
        }
    }
}
