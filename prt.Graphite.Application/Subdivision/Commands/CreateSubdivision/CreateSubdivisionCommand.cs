using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Subdivision.Commands.CreateSubdivision
{
    public class CreateSubdivisionCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? BrigadeId { get; private set; }

        public CreateSubdivisionCommand(Guid id, string name, Guid? brigadeId)
        {
            Id = id;
            Name = name;
            BrigadeId = brigadeId;
        }
    }
}
