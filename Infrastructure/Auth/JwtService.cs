using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Application.Interfaces.Services;
using Domain.Entities.Account;
using Infrastructure.Options;

namespace Infrastructure.Auth
{
    public class JwtService(IOptions<AuthenticationSettings> options) : IJwtService
    {
        public string GenerateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("userName", account.UserName),
                new Claim("firstName", account.FirstName),
                new Claim("id", account.Id.ToString()),
                new Claim(ClaimTypes.Role, account.Role.ToString())
            };

            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(options.Value.SecretKey)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(options.Value.Expires),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
