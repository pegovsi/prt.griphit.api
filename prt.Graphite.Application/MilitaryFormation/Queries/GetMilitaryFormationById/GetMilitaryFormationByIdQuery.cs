using MediatR;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.GetMilitaryFormationById
{
    public class GetMilitaryFormationByIdQuery : IRequest<MilitaryFormationDto>
    {
        public Guid MilitaryFormationId { get; }

        public GetMilitaryFormationByIdQuery(Guid militaryFormationId)
        {
            MilitaryFormationId = militaryFormationId;
        }
    }
}
