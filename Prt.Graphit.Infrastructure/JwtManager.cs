using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Prt.Graphit.Identity.Common;
using Prt.Graphit.Identity.Common.Models;

namespace Prt.Graphit.Infrastructure
{
    public class JwtManager : IJwtManager
    {
        public SessionUser GenerationToken(ClaimsIdentity identity, ApplicationUser account)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthorizationOptions.ISSUER,
                audience: AuthorizationOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthorizationOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthorizationOptions.Create(AuthorizationOptions.KEY),
                    SecurityAlgorithms.HmacSha256));

            jwt.Payload["user_id"] = account.AccountId;
            jwt.Payload["iat"] = now.TimeOfDay.Ticks;
            jwt.Payload["login"] = account.Login;
            jwt.Payload["first_name"] = account.FirstName;
            jwt.Payload["middle_name"] = account.MiddleName;
            jwt.Payload["last_name"] = account.LastName;
            jwt.Payload["roles"] = account.Roles.Select(x => x.Mnemonic).ToArray();
            

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new SessionUser
            {
                Date = now,
                Duration = AuthorizationOptions.LIFETIME,
                Token = encodedJwt,
                UserId = account.AccountId.ToString(),
                User = identity.Name
            };
        }
    }
}