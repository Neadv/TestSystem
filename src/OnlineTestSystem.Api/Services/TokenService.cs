using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineTestSystem.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineTestSystem.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly Infrastructure.TokenOptions _tokenOptions;

        public TokenService(IOptions<Infrastructure.TokenOptions> options)
        {
            _tokenOptions = options.Value;
        }

        public string GenerateToken(ApplicationUser user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var claims = GetClaims(user);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(_tokenOptions.LifeTime)),
                signingCredentials: new SigningCredentials(_tokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private IEnumerable<Claim> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            return claims;
        }
    }
}
