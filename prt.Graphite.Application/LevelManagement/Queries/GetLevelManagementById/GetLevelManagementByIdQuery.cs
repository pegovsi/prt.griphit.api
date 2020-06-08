using MediatR;
using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.LevelManagement.Queries.GetLevelManagementById
{
    public class GetLevelManagementByIdQuery : IRequest<LevelManagementDto>
    {
        public Guid LevelManagementId { get; }

        public GetLevelManagementByIdQuery(Guid levelManagementId)
        {
            LevelManagementId = levelManagementId;
        }
    }
}
