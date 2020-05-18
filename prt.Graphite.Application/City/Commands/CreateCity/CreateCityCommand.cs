using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.City.Commands.CreateCity
{
    public class CreateCityCommand : IRequest<Result<bool>>
    {
        public CreateCityCommand(Guid id, string name, Guid? garrisonId)
        {
            Id = id;
            Name = name;
            GarrisonId = garrisonId;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? GarrisonId { get; private set; }
    }
}
