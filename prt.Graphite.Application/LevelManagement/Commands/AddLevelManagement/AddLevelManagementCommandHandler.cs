using AutoMapper;
using MediatR;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Domain.AggregatesModel.LeveManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.LevelManagement.Commands.AddLevelManagement
{
    public class AddLevelManagementCommandHandler : HandlerQueryBase<AddLevelManagementCommand, Unit>
    {
        public AddLevelManagementCommandHandler(IAppDbContext appDbContext, IMapper mapper)
            : base(appDbContext, mapper)
        {
        }

        public override async Task<Unit> Handle(AddLevelManagementCommand request, CancellationToken cancellationToken)
        {
            var levelManagement = new Domain.AggregatesModel.LeveManagement.Entities.LevelManagement
            (
                name: request.Name,
                code: request.Code,
                isVch: request.IsVCH,
                independent: request.Independent
            );

            levelManagement.SetActiveStatus(Domain.Enumerations.ActiveStatus.Active);

            await ContextDb.Set<Domain.AggregatesModel.LeveManagement.Entities.LevelManagement>()
                .AddAsync(levelManagement, cancellationToken);

            await ContextDb.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
