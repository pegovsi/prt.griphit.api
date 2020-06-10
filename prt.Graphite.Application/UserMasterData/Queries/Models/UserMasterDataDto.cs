using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.UserMasterData.Queries.Models
{
    public class UserMasterDataDto
    {
        public Guid Id { get; private set; }
        public Guid VehicleModelId { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<UserMasterDataFieldDto> UserMasterDataFields { get; private set; }
    }

    public class UserMasterDataFieldDto
    {
        public Guid Id { get; private set; }
        public Guid UserMasterDataId { get; private set; }
        public string NameField { get; private set; }
        public Guid TypeUserMasterDataId { get; private set; }
        public TypeUserMasterDataDto TypeUserMasterData { get; private set; }
    }

    public class TypeUserMasterDataDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }

    public class UserMasterDataValueDto
    {
        public Guid Id { get; private set; }
        public Guid UserMasterDataId { get; private set; }
        public Guid UserMasterDataFieldId { get; private set; }
        public UserMasterDataFieldDto UserMasterDataField { get; private set; }
        public Guid VehicleId { get; private set; }
        public UserMasterDataContentDto Content { get; private set; }
    }

    public class UserMasterDataContentDto
    {
        public dynamic Value { get; private set; }
    }
}
