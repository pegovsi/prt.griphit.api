using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class VehicleType : Entity
    {
        protected VehicleType() { }

        public VehicleType(string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = Guid.NewGuid();
            Name = name;
        }

        public VehicleType(Guid id, string name)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
        }
        public VehicleType(Guid id, string name, string iconLink, string pictureLink)
            : this()
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException($"Незаполнено обязательное поле {nameof(name)}");

            Id = id;
            Name = name;
            IconLink = iconLink;
            PictureLink = pictureLink;
        }


        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public string IconLink { get; private set; }
        public string PictureLink { get; private set; }

        public void SetIconLink(string iconLink)
        {
            IconLink = iconLink;
        }
        public void SetPictureLink(string pictureLink)
        {
            PictureLink = pictureLink;
        }
    }
}
