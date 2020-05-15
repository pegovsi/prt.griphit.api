using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.Chassis.Commands.CreateChassis
{
    public class CreateChassisCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? ManufacturerId { get; private set; }

        public CreateChassisCommand(Guid id, string name, Guid? manufacturerId)
        {
            Id = id;
            Name = name;
            ManufacturerId = manufacturerId;
        }
    }
}
