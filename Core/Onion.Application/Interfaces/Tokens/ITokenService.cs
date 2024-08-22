using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Onion.Domain.Entities;

namespace Onion.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user , IList<string> roles);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken();
    }
}
