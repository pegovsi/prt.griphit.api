using MediatR;
using Newtonsoft.Json;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.UserMasterData.Commands.Create
{
    public class CreateUserMasterDataCommand : IRequest<Result<Guid>>
    {
        [JsonProperty("vehicleModelId")]
        public Guid VehicleModelId { get; }
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("userMasterDataFields")]
        public IEnumerable<UserMasterDataFieldCommand> UserMasterDataFields { get; }

        public CreateUserMasterDataCommand(Guid vehicleModelId, string name, IEnumerable<UserMasterDataFieldCommand> userMasterDataFields)
        {
            VehicleModelId = vehicleModelId;
            Name = name;
            UserMasterDataFields = userMasterDataFields;
        }
    }

    public class UserMasterDataFieldCommand
    {
        [JsonProperty("name")]
        public string Name { get; }
        [JsonProperty("typeUserMasterDataId")]
        public Guid TypeUserMasterDataId { get; }

        public UserMasterDataFieldCommand(string name, Guid typeUserMasterDataId)
        {
            Name = name;
            TypeUserMasterDataId = typeUserMasterDataId;
        }
    }
}
