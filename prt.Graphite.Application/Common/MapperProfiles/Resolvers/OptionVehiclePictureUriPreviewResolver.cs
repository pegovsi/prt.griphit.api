using AutoMapper;
using Microsoft.Extensions.Options;
using Prt.Graphit.Api.Common.Settings.Models;
using Prt.Graphit.Domain.AggregatesModel.Vehicle.Entities;

namespace Prt.Graphit.Application.Common.MapperProfiles.Resolvers
{
    public class OptionVehiclePictureUriPreviewResolver : IValueResolver<VehiclePicture, object, string>
    {
        private readonly IOptions<Host> _service;
        public OptionVehiclePictureUriPreviewResolver(IOptions<Host> service)
            => _service = service;


        public string Resolve(VehiclePicture source,
            object destination,
            string destMember,
            ResolutionContext context)
            => $"{_service.Value.Address}/api/v1/vehicles/vehicle-images{source.UriPreview}";

    }
}
