using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        //private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            //var currentUser = _currentUserService.GetCurrentUser();
            var name = typeof(TRequest).Name;

            _logger.LogInformation(
                "ProjectManagement Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}
