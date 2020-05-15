﻿using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class VehicleModel : Entity
    {
        protected VehicleModel() { }

        public VehicleModel(string name)
           : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public VehicleModel(string name, string shortName, Guid vehicleModelId, Guid chassiId)
           : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (vehicleModelId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(vehicleModelId)}");

            if (chassiId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(chassiId)}");

            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
            VehicleModelId = vehicleModelId;
            ChassiId = chassiId;
        }
        public VehicleModel(Guid id, string name, string shortName, Guid vehicleModelId, Guid chassiId)
          : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            if (vehicleModelId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(vehicleModelId)}");

            if (chassiId == Guid.Empty)
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(chassiId)}");

            Id = id;
            Name = name;
            ShortName = shortName;
            VehicleModelId = vehicleModelId;
            ChassiId = chassiId;
        }

        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public Guid VehicleModelId { get; private set; }
        public Guid ChassiId { get; private set; }
        public string IconLink { get; private set; }


        public void SetIconLink(string iconLink)
        {
            IconLink = iconLink;
        }
    }
}

