using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.Division.Commands.CreateDivision
{
    public class CreateDivisionCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public CreateDivisionCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
