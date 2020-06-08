using Prt.Graphit.Application.ActiveStatus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.LevelManagement.Queries.Models
{
    public class LevelManagementDto
    {
        public Guid Id { get; private set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Является в/ч
        /// </summary>
        public bool IsVCH { get; private set; }
        /// <summary>
        /// Самостоятельный
        /// </summary>
        public bool Independent { get; private set; }
        
        public ActiveStatusDto ActiveStatus { get; private set; }
    }
}
