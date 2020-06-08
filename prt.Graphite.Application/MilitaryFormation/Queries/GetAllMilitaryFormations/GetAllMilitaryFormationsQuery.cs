using MediatR;
using Prt.Graphit.Application.MilitaryFormation.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.GetAllMilitaryFormations
{
    public class GetAllMilitaryFormationsQuery : IRequest<MilitaryFormationDto[]>
    {
    }
}
