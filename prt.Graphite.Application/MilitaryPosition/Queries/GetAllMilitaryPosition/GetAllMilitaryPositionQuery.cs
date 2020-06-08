using MediatR;
using Prt.Graphit.Application.MilitaryPosition.Queries.Models;

namespace Prt.Graphit.Application.MilitaryPosition.Queries.GetAllMilitaryPosition
{
    public class GetAllMilitaryPositionQuery : IRequest<MilitaryPositionDto[]>
    {
    }
}
