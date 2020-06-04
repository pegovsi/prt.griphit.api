using MediatR;
using Microsoft.Extensions.Options;
using Prt.Graphit.Api.Common.Settings.Models;
using Prt.Graphit.Application.Common.Services;
using Prt.Graphit.Application.Map.Queries.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Prt.Graphit.Application.Map.Queries.GetTitle
{
    public class GetTitleQueryHandler : IRequestHandler<GetTitleQuery, FileContainer>
    {
        private readonly IOptions<OperationSystem> _os;
        private readonly IOptions<MapCatalog> _options;

        public GetTitleQueryHandler(IOptions<OperationSystem> os, IOptions<MapCatalog> options)
        {
            _os = os;
            _options = options;
        }

        public async Task<FileContainer> Handle(GetTitleQuery request, CancellationToken cancellationToken)
        {
            var catalog = _options.Value.Path;
            var path = string.Empty;

            var z = request.Z.Replace("{", string.Empty).Replace("}", string.Empty);
            var x = request.X.Replace("{", string.Empty).Replace("}", string.Empty);
            var y = request.Y.Replace("{", string.Empty).Replace("}", string.Empty);

            if (_os.Value.Platform == PlatformID.Unix)
                path = $"{catalog}/{z}/{x}/{y}.png";
            else
                path = $@"{catalog}\{z}\{x}\{y}.png";

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
