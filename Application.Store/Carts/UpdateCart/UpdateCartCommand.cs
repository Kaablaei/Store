using Domain.Invoices.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carts.UpdateCart
{
    public record UpdateCartCommand(int Id ,decimal Price, decimal SalePrice, int count, int variationid) : IRequest<UpdateCartCommandResponse>;



    public record UpdateCartCommandResponse(int Id);

    public class UpdateCartCommandHandler(ICartRepository repository) : IRequestHandler<UpdateCartCommand, UpdateCartCommandResponse>
    {
        public async Task<UpdateCartCommandResponse> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = repository.GetById(request.Id);
            if (cart == null)
                throw new Exception("cart not found");

            cart.Update(request.Price, request.SalePrice, request.count,request.variationid);

            repository.Update(cart);

            return new UpdateCartCommandResponse(cart.Id);

        }
    }
}
