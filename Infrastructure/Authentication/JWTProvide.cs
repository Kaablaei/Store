using Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class JWTProvide
    {
        private readonly JwtOptions _options;

        public JWTProvide(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string Genertge(User user)
        {
            var cleaim = new Claim[] 
            {
            
                new Claim (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Email, user.Email),
            };

            var signingCredenials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secretkey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               _options.Issuer,
                _options.Audience,
                cleaim,
                null,
                DateTime.UtcNow.AddHours(1),
                null);

           string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;

        }
    }

    public class JwtOptions
    {

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secretkey { get; set; }
    }


}
