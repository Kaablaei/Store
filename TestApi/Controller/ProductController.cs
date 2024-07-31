using API.DTOs;
using Application.Products.CreateProduct;
using Application.Products.DeletProduct;
using Application.Products.GetProduct;
using Application.Products.GetProducts;
using Application.Products.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int pageNo)
        {
            var result = await mediator.Send(new GetProductsQuery(pageNo, 10));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductQuery(id);
            var result = await mediator.Send(query);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto requestDto)
        {

            var command = new CreateProductCommand(requestDto.SKU, requestDto.Title, requestDto.CategoryId);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string SKU, string Title, int CategoryId)
        {
            var Command = new UpdateProductCommand(id, SKU, Title, CategoryId);
            var result = await mediator.Send(Command);
           if(result == null)
            {
                return NotFound();
            } 
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Command = new DeleteProductCommand(id);
            var result = await mediator.Send(Command);
            if (result == null) return NotFound();
            return NoContent();
        }
    }
}
