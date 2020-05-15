using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Prt.Graphit.Sku.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>();
    }
}