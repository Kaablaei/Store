using API.DTOs;
using Application.Categorys.CreateCategory;
using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using Application.Products.CreateProduct;
using Application.Products.GetProduct;
using Application.Products.GetProducts;
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
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto requestDto)
        {
            if (requestDto.CategoryId == null) return NotFound();


            var command = new CreateProductCommand(requestDto.SKU,requestDto.Title,requestDto.CategoryId);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        }



    }
}
