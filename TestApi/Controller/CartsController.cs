using API.DTOs;
using Application.Carts.CreateCart;
using Application.Carts.DeleteCart;
using Application.Carts.GetCart;
using Application.Carts.GetCarts;
using Application.Carts.UpdateCart;
using Application.Categories.DeleteCategory;
using Application.Categories.UpdateCategory;
using Application.Categorys.CreateCategory;
using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int pageNo)
        {
            var result = await mediator.Send(new GetCartSQuery(pageNo, 10));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCartQuer(id);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartsDto requestDto)
        {
            var command = new CreateCartCommend(requestDto.UserId, requestDto.VaridationId, requestDto.Price, requestDto.SalePrice);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int Id, decimal Price, decimal SalePrice, int count, int variationid)
        {

            var Find = new GetCartQuer(Id);
            if (Find == null)
            {
                return NotFound();
            }
            try
            {
                var Command = new UpdateCartCommand(Id, Price, SalePrice, count, variationid);
                var result = await mediator.Send(Command);
                return Ok(result);
            }
            catch
            {

                return BadRequest();
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var Find = new GetCartQuer(id);
            if (Find == null)
            {
                return NotFound();
            }

            var Command = new DeleteCartCommand(id);
            var result = await mediator.Send(Command);
            return Ok(result);
        }
    }
}
