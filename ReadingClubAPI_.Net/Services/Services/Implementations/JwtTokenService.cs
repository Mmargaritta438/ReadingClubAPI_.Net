using Microsoft.IdentityModel.Tokens;
using ReadingClubSPI_.Net.BusinessReadClBookLayer.Exceptions;
using ReadingClubSPI_.Net.DataReadClBookLayer.Models;
using ReadingClubSPI_.Net.Services.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReadingClubSPI_.Net.Services.Services.Implementations
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(UserBook user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
            };

            var jwtKey = _config["JwtSettings:Key"] ?? throw new ConfigurationKeyNotFoundException("JWT key is null!");

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            );

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"] ?? throw new ConfigurationKeyNotFoundException("JWT Issuer is null!"),
                audience: _config["JwtSettings:Audience"] ?? throw new ConfigurationKeyNotFoundException("JWT Audience is null!"),
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}