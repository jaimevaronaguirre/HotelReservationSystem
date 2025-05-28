using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HotelReservationSystem.Application.Abstractions.Authentication;
using HotelReservationSystem.Application.Abstractions.Data;
using HotelReservationSystem.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystem.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public JwtProvider(
            IOptions <JwtOptions> options,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _options = options.Value;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<string> Generate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!.Value.ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email!.Value)
            };


            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey!)),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddDays(365),
                signingCredentials
            );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;

        }
    }
}
