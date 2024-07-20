using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using Application.Products.GetProduct;
using Application.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int pageNo)
        {
            var result = await mediator.Send(new GetProductsQuery(pageNo, 1));
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

    }
}
