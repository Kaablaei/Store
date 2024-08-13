using API.DTOs;
using Application.Users.Create;
using Application.Users.DeleteUser;
using Application.Users.Get;
using Application.Users.GetAll;
using Application.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int pageNo)
        {
            var result = await mediator.Send(new GetUsersQuery(pageNo, 10));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var result = await mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDro requestDto)
        {
            var command = new CreateUserCommand(requestDto.Name,requestDto.Family,requestDto.Phone,requestDto.Email,requestDto.Password);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name, string family)
        {
            var Command = new UpdateUserCommand(id, name,family);
            var result = await mediator.Send(Command);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Command = new DeleteUserCommand(id);
            var result = await mediator.Send(Command);
            if (result == null) return NotFound();
            return NoContent();
        }
    }
}
