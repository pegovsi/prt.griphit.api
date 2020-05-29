using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Application.Common.Response;
using Prt.Graphit.Application.Common.Services;
using Prt.Graphit.Application.Identity.Queries.Models;
using Prt.Graphit.Application.Interfaces;
using Prt.Graphit.Domain.AggregatesModel.Account.Entities;
using Prt.Graphit.Identity.Common.Models;


namespace Prt.Graphit.Application.Identity.Queries.Authenticated
{
    public class AuthenticatedQueryHandler : IRequestHandler<AuthenticatedQuery, Result<IdentityResponse>>
    {
        private readonly IAppDbContext _context;
        private readonly IJwtManager _jwtManager;

        public AuthenticatedQueryHandler(IAppDbContext context, IJwtManager jwtManager)
        {
            _context = context;
            _jwtManager = jwtManager;
        }

        public async Task<Result<IdentityResponse>> Handle(AuthenticatedQuery request, CancellationToken cancellationToken)
        {
            var account = await FindUser(request.Login, request.Password, cancellationToken);
            if (account is null)
                return ResultHelper.Error<IdentityResponse>("Ошибка аутентификации");
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString(), ClaimValueTypes.String),
                new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login, ClaimValueTypes.String)
                //new Claim(ClaimsIdentity.DefaultRoleClaimType, string.Join(";", account.Roles?.Select(x=>x.Mnemonic)))
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var applicationUser = new ApplicationUser
            {
                Login = account.Login,
                AccountId = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                MiddleName = account.MiddleName,
                IsConfirm = account.IsConfirm,
                Roles = null,
                IsDisabled = account.Deleted != null

            };
            var session = _jwtManager.GenerationToken(claimsIdentity, applicationUser);

            var response = new IdentityResponse
            {
                Token = session.Token
            };
            return ResultHelper.Success<IdentityResponse>(response);
            
        }
        
        private async Task<Account> FindUser(string login, string password, CancellationToken token)
        {
            var account = await _context.Set<Account>()
                .FirstOrDefaultAsync(x=>x.Login == login, token);

            if (account is null)
                return null;

            var passwordHash = EncoderService.GetSHA256(login, password);

            if (account.Password != passwordHash)
                return null;

            return account;
        }
    }
}