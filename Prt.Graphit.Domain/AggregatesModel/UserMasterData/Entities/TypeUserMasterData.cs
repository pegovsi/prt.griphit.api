using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities
{
    public class TypeUserMasterData : Entity
    {
        protected TypeUserMasterData() { }
        public TypeUserMasterData(string typeData)
        {
            TypeData = typeData;
        }
        public TypeUserMasterData(string typeData, string description)
        {
            TypeData = typeData;
            Description = description;
        }
        public override Guid Id { get; protected set; }
        public string TypeData { get; private set; }
        public string Description { get; private set; }
    }
}
