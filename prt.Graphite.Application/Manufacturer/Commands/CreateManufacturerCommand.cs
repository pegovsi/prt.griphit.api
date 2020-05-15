using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.Manufacturer.Commands
{
    public class CreateManufacturerCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public CreateManufacturerCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
