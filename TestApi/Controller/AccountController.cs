using API.DTOs.Account;
using Application.Users.Create;

using Domain.Users;
using Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


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
        private readonly JWTProvide _jwtProvide;

        public AccountController(IMediator mediator, IConfiguration configuration
            , UserManager<User> userManager,
            SignInManager<User> SininManager
            , JWTProvide jwtProvide

            )
        {
            _SininManager = SininManager;
            _userManager = userManager;
            _mediator = mediator;
            _configuration = configuration;
            _jwtProvide = jwtProvide;   
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(model.Usename);
            if (user == null)
            {
                return BadRequest("اطلاعات درست نیست ");
            }

            var token = _jwtProvide.Genertge(user);
            return Ok(new { Token = token });

           
        }


        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _SininManager.SignOutAsync();
            return NoContent();
        }
    }


}


