using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.MilitaryPosition.Commands.AddMilitaryPosition
{
    public class AddMilitaryPositionCommand : IRequest<Result<Guid>>
    {
        public string Name { get; }
        public string ShortName { get; }

        public AddMilitaryPositionCommand(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }
    }
}
