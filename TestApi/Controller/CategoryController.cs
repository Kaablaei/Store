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
            var result =await mediator.Send(new GetCategoriesQuery(pageNo,10));

            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Getone(int id)
        {
            var rezalt = await mediator.Send(new GetCategoryQuery(id));
            if(rezalt == null)
            {

                return BadRequest();
            }

            return Ok(rezalt);
        }
    }
}
