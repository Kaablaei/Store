using API.DTOs;
using Application.Carts.CreateCart;
using Application.Carts.GetCart;
using Application.Carts.GetCarts;
using Application.Categorys.CreateCategory;
using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var command = new CreateCartCommend(requestDto.UserId,requestDto.VaridationId,requestDto.Price,requestDto.SalePrice);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
        }


    }
}
