using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.MilitaryFormation.Commands.AddMilitaryFormation
{
    public class AddMilitaryFormationCommand : IRequest<Unit>
    {
        public string Name { get; }
        public string ShortName { get; }
        public string MilitaryNameUnit { get; }
        public Guid? ParentId { get; }
        public Guid? LevelManagementId { get; }

        public AddMilitaryFormationCommand(string name, string shortName, string militaryNameUnit, Guid? parentId, Guid? levelManagementId)
        {
            Name = name;
            ShortName = shortName;
            MilitaryNameUnit = militaryNameUnit;
            ParentId = parentId;
            LevelManagementId = levelManagementId;
        }
    }
}