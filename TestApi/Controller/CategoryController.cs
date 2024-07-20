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
            var result =await mediator.Send(new GetCategoriesQuery(pageNo,30));

            return Ok(result);
        }

   
     
    }
}
