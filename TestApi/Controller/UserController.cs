using API.DTOs;
using Application.Categories.DeleteCategory;
using Application.Categories.UpdateCategory;
using Application.Categorys.CreateCategory;
using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using Application.Users.Create;
using Application.Users.DeleteUser;
using Application.Users.Get;
using Application.Users.GetAll;
using Application.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDro requestDto)
        {
            var command = new CreateUserCommand(requestDto.Name,requestDto.Family,requestDto.Phone,requestDto.Email);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name, string family)
        {
            var Command = new UpdateUserCommand(id, name,family);
            var result = await mediator.Send(Command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Command = new DeleteUserCommand(id);
            var result = await mediator.Send(Command);
            return NoContent();
        }
    }
}
