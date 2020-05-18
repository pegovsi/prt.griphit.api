using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.Garrison.Commands.CreateGarrison
{
    public class CreateGarrisonCommand : IRequest<Result<bool>>
    {
        public CreateGarrisonCommand(Guid id, string name, decimal coordinateX, decimal coordinateY, int rate)
        {
            Id = id;
            Name = name;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            Rate = rate;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal CoordinateX { get; private set; }
        public decimal CoordinateY { get; private set; }
        public int Rate { get; private set; }
    }
}
