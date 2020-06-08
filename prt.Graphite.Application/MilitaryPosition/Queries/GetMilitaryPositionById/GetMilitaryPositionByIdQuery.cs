using MediatR;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;
using System;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.GetMilitaryPositionById
{
    public class GetMilitaryPositionByIdQuery : IRequest<MilitaryPositionDto>
    {
        public Guid MilitaryPositionId { get; }

        public GetMilitaryPositionByIdQuery(Guid militaryPositionId)
        {
            MilitaryPositionId = militaryPositionId;
        }
    }
}
