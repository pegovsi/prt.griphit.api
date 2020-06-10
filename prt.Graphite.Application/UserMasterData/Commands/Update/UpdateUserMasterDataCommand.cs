using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.UserMasterData.Commands.Update
{
    public class UpdateUserMasterDataCommand : IRequest<Result<bool>>
    {
        public Guid UserMasterDataId { get; }
        public string Name { get; }
        public IEnumerable<UserMasterDataFieldCommand> UserMasterDataFields { get; }

        public UpdateUserMasterDataCommand(Guid userMasterDataId, string name, IEnumerable<UserMasterDataFieldCommand> userMasterDataFields)
        {
            UserMasterDataId = userMasterDataId;
            Name = name;
            UserMasterDataFields = userMasterDataFields;
        }
    }

    public class UserMasterDataFieldCommand
    {
        public Guid UserMasterDataFieldId { get; }
        public string Name { get; }
        public Guid TypeUserMasterDataId { get; }
        public int Modified { get; }

        public UserMasterDataFieldCommand(Guid userMasterDataFieldId, string name, Guid typeUserMasterDataId, int modified)
        {
            UserMasterDataFieldId = userMasterDataFieldId;
            Name = name;
            TypeUserMasterDataId = typeUserMasterDataId;
            Modified = modified;
        }

        /* int Modified
         * 1 = new
         * 2 = update
         * 3 = delete
         */

    }
}
