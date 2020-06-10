using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.UserMasterData.Commands.Create
{
    public class CreateUserMasterDataCommand : IRequest<Result<Guid>>
    {
        public Guid VehicleModelId { get; }
        public string Name { get; }
        public IEnumerable<UserMasterDataFieldCommand> UserMasterDataFields { get; }
    }

    public class UserMasterDataFieldCommand 
    {
        public string Name { get; }
        public Guid TypeUserMasterDataId { get; }
    }
}
