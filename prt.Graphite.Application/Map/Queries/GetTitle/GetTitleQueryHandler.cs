using MediatR;
using Microsoft.Extensions.Options;
using Prt.Graphit.Api.Common.Settings.Models;
using Prt.Graphit.Application.Common.Services;
using Prt.Graphit.Application.Map.Queries.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Map.Queries.GetTitle
{
    public class GetTitleQueryHandler : IRequestHandler<GetTitleQuery, FileContainer>
    {
        private readonly IOptions<Api.Common.Settings.Models.OperationSystem> _os;
        private readonly IOptions<Api.Common.Settings.Models.MapCatalog> _options;

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

            if (_os.Value.Platform == System.PlatformID.Unix)
                path = $"{catalog}/{z}/{x}/{y}.png";
            else
                path = $@"{catalog}\{z}\{x}\{y}.png";

            FileInfo fileInfo = new FileInfo(path);
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
