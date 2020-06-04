using MediatR;
using Microsoft.Extensions.Options;
using Prt.Graphit.Api.Common.Settings.Models;
using Prt.Graphit.Application.Common.Services;
using Prt.Graphit.Application.Map.Queries.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Vehicle.Queries.GetVehicleImage
{
    public class GetVehicleImageQueryHandler : IRequestHandler<GetVehicleImageQuery, FileContainer>
    {
        private readonly IOptions<OperationSystem> _os;
        private readonly IOptions<PictureCatalog> _options;

        public GetVehicleImageQueryHandler(IOptions<OperationSystem> os,
            IOptions<PictureCatalog> options)
        {
            _os = os;
            _options = options;
        }

        public async Task<FileContainer> Handle(GetVehicleImageQuery request, CancellationToken cancellationToken)
        {
            var picturePath = _options.Value.Path;
            var path = string.Empty;


            if (_os.Value.Platform == System.PlatformID.Unix)
                path = $"{picturePath}/{request.VehicleId}/{request.FileName}";
            else
                path = $@"{picturePath}\{request.VehicleId}\{request.FileName}";

            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
                return null;

            var file = File.OpenRead(path);
            var contentType = FileHelper.GetContentType(fileInfo.Extension);
            return await Task.FromResult(new FileContainer
            {
                Data = file,
                FileName = fileInfo.Name,
                Extension = fileInfo.Extension,
                ContentType = contentType.TypeFileString
            });
        }
    }
}
