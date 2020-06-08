using MediatR;
using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.LevelManagement.Queries.GetAllLevelManagement
{
    public class GetAllLevelManagementQuery : IRequest<LevelManagementDto[]>
    {
        public GetAllLevelManagementQuery()
        {

        }
    }
}
