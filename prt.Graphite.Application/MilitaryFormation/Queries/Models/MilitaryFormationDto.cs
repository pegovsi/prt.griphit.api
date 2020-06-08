using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.MilitaryFormation.Queries.Models
{
    public class MilitaryFormationDto
    {
        public Guid Id { get;  private set; }
        public Guid? ParentId { get; private set; }
        public MilitaryFormationDto Parent { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }

        /// <summary>
        /// Уровни управления
        /// </summary>
        public Guid? LevelManagementId { get; private set; }
        public LevelManagementDto LevelManagement { get; private set; }
    }
}
