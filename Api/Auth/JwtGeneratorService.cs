using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MiSide.Domain.Entities;

namespace Api.Auth
{
    public class JwtGeneratorService(IOptions<AuthenticationSettings> options)
    {
        public string GenerateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("userName", account.UserName),
                new Claim("firstName", account.FirstName),
                new Claim("id", account.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(options.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(options.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
