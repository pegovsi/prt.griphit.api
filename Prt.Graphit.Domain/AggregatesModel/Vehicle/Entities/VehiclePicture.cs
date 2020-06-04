using Prt.Graphit.Domain.Common;
using System;

namespace Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities
{
    public class VehiclePicture : Entity
    {
        protected VehiclePicture()
            :base()
        {
        }
        public VehiclePicture(Guid vehicleId, string uri, string uriPreview)
        {
            Id = Guid.NewGuid();
            IsNew = true;
            VehicleId = vehicleId;
            Uri = uri;
            UriPreview = uriPreview;
        }

        public override Guid Id { get; protected set; }
        public Guid VehicleId { get; }
        public string Uri { get; private set; }
        public string UriPreview { get; private set; }
        /// <summary>
        /// Основная картинка
        /// </summary>
        public bool Base { get; private set; }

        public void SetUri(string uri)
        {
            Uri = uri;
        }
        public void SetUriPreview(string uriPreview)
        {
            UriPreview = uriPreview;
        }

        public void SetBase()
        {
            Base = true;
        }
        public void TakeOfBase()
        {
            Base = false;
        }
    }
}
