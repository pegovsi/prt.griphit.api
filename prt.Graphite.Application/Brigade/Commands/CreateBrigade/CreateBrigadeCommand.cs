using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;

namespace Prt.Graphit.Application.Brigade.Commands.CreateBrigade
{
    public class CreateBrigadeCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? DivisionId { get; private set; }

        public CreateBrigadeCommand(Guid id, string name, Guid? divisionId)
        {
            Id = id;
            Name = name;
            DivisionId = divisionId;
        }
    }
}
