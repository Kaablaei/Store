using Application.Categorys.GetCatrgory;
using Application.Categorys.GetCatrgorys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{

    [ApiController]
    public class CategoryController() : ControllerBase
    {
        ////IMediator mediator
        //[Route("Get")]
        //public async Task<IActionResult> Get(int pageNo)
        //{
        //    var result =await mediator.Send(new GetCategoriesQuery(pageNo,30));
        //    return Ok(result);
        //}
    }
}
