using AutoMapper;
using MediatR;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.MilitaryFormation.Commands.AddMilitaryFormation
{
    public class AddMilitaryFormationCommandHandler :
        HandlerQueryBase<AddMilitaryFormationCommand, Unit>
    {
        public AddMilitaryFormationCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Unit> Handle(AddMilitaryFormationCommand request,
            CancellationToken cancellationToken)
        {
            var militaryFormation = new Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation
            (
                name: request.Name,
                shortName: request.ShortName,
                militaryNameUnit: request.MilitaryNameUnit,
                parentId: request.ParentId,
                levelManagementId: request.LevelManagementId
            );

            militaryFormation.SetActiveStatus(Domain.Enumerations.ActiveStatus.Active);
            await ContextDb.Set<Domain.AggregatesModel.MilitaryFormation.Entities.MilitaryFormation>()
                .AddAsync(militaryFormation, cancellationToken);

            await ContextDb.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
