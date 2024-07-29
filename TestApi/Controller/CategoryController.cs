using API.DTOs;
using Application.Carts.GetCart;
using Application.Categories.DeleteCategory;
using Application.Categories.UpdateCategory;
using Application.Categorys.CreateCategory;
using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int pageNo)
        {
            var result = await mediator.Send(new GetCategoriesQuery(pageNo, 10));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoryQuery(id);
            var result = await mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CatrgoryDto requestDto)
        {
            var command = new CreateCategoryCommand(requestDto.Name);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            var Command = new UpdateCategoryCommand(id, name);
            var result = await mediator.Send(Command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Command = new DeleteCategoryCommand(id);
            var result = await mediator.Send(Command);
            return NoContent();
        }
    }
}
