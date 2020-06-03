using Newtonsoft.Json;
using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Domain.AggregatesModel.Crew.Entities
{
    /// <summary>
    /// История изменений по экипажу
    /// </summary>
    public class CrewHistory : Entity
    {
        protected CrewHistory()
        {
        }

        public CrewHistory(Guid crewId, CrewHistoryContent content)
            : base()
        {
            Id = Guid.NewGuid();
            CrewId = crewId;
            _content = JsonConvert.SerializeObject(content);
        }

        public override Guid Id { get; protected set; }
        public Guid CrewId { get; private set; }
        private string _content;
        public CrewHistoryContent Content
            => JsonConvert.DeserializeObject<CrewHistoryContent>(_content);
    }

    public class CrewHistoryContent
    {
        public CrewHistoryContent(DateTime orderDate, Guid vehicleId,
            List<CrewHistoryContentPosition> crewHistoryContentPositions)
        {
            Id = Guid.NewGuid();
            OrderDate = orderDate;
            VehicleId = vehicleId;
            CrewHistoryContentPositions = crewHistoryContentPositions;
        }
        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Guid VehicleId { get; private set; }
        public List<CrewHistoryContentPosition> CrewHistoryContentPositions { get; private set; }

    }
    public class CrewHistoryContentPosition
    {
        public CrewHistoryContentPosition(Guid crewPositionId, Guid accountId)
        {
            CrewPositionId = crewPositionId;
            AccountId = accountId;
        }
        public Guid CrewPositionId { get; private set; }
        public Guid AccountId { get; private set; }
    }
}
