using AutoMapper;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Crew.Commands.AddCrew
{
    public class AddCrewCommandHandler : HandlerQueryBase<AddCrewCommand, Result<Guid>>
    {
        public AddCrewCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Result<Guid>> Handle(AddCrewCommand request, CancellationToken cancellationToken)
        {
            var crew = new Domain.AggregatesModel.Crew.Entities.Crew
            (
                orderNumber: request.OrderNumber,
                orderDateStart: request.OrderDateStart,
                orderDateFinish: request.OrderDateFinish,
                typesMilitaryOrderId: request.TypesMilitaryOrderId,
                vehicleId: request.VehicleId,
                militaryFormationId: request.MilitaryFormationId
            );

            foreach (var position in request.CrewPositions)
            {
                crew.AddCrewPosition(position.MilitaryPositionId, position.AccountId);
            }

            await ContextDb.Set<Domain.AggregatesModel.Crew.Entities.Crew>()
                .AddAsync(crew, cancellationToken);

            await ContextDb.SaveChangesAsync(cancellationToken);

            return ResultHelper.Success<Guid>(crew.Id);
        }
    }
}
