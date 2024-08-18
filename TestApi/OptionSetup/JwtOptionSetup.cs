using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.OptionSetup
{
    public class JwtOptionSetup : IConfigureOptions<JwtOptions>
    {
        private readonly IConfiguration _confogoration;
        private string SectionName = "Jwt";

        public JwtOptionSetup(IConfiguration confogoration)
        {
            _confogoration = confogoration;
        }

        public void Configure(JwtOptions options)
        {
            _confogoration.GetSection(SectionName).Bind(options);



        }
    }

    public class JwtBeareOptionSetup : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions  _jwtOptions;
        public JwtBeareOptionSetup(IOptions< JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;   
        }
        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true ,
               ValidIssuer=_jwtOptions.Issuer,
               ValidAudience = _jwtOptions.Audience,
               IssuerSigningKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(_jwtOptions.Secretkey))
            };
        }
    }
}
