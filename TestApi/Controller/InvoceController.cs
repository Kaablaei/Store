using API.DTOs;
using Application.Carts.CreateCart;
using Application.Carts.GetCart;
using Application.Carts.GetCarts;
using Application.Carts.UpdateCart;
using Application.Invoices.CreateInvoice;
using Application.Invoices.Get;
using Application.Invoices.GetInvoices;
using Application.Invoices.Update;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoceController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get(int pageNo)
        {
            var result = await mediator.Send(new GetInvoicesQuery(pageNo, 10));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetInvoiceQuery(id);
            var result = await mediator.Send(query);
            if (result == null) return NotFound();
          
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoceDto requestDto)
        {
            var command = new CreateInvoiceCommand(requestDto.InvoiceNo,requestDto.AdressId,requestDto.Discount);
            var result = await mediator.Send(command);
          
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,InvoiceStatus status, string trackigcode)
        {
            var Command = new UpdateInvoiceCommand(id, status,trackigcode);
            var result = await mediator.Send(Command);
            if (result == null) return NotFound();
            return Ok();
        }
    }
}
