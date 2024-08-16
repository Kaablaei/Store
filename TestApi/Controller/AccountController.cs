using API.DTOs.Account;
using Application.Users.Create;
using Application.Users.Get;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _SininManager;

        public AccountController(IMediator mediator, IConfiguration configuration
            , UserManager<User> userManager,
            SignInManager<User> SininManager
            )
        {
            _SininManager = SininManager;
            _userManager = userManager;
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    Family = model.Family,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var command = new CreateUserCommand(model.Name, model.Family, model.Phone, model.Email, model.Password);
                    var commandResult = await _mediator.Send(command);
                    return Ok(commandResult);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(nameof(model.Email), error.Description);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _SininManager.PasswordSignInAsync(model.Usename, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Usename);


                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, model.Usename),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Issuer"],
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
                return Unauthorized("اطلاعات اشتباه است ");
            }

            return BadRequest(ModelState);
        }

    }


}


