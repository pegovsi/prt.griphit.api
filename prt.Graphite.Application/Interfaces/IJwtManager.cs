using System.Security.Claims;
using Prt.Graphit.Identity.Common.Models;

namespace Prt.Graphit.Application.Interfaces
{
    public interface IJwtManager
    {
        SessionUser GenerationToken(ClaimsIdentity claim, ApplicationUser account);
    }
}