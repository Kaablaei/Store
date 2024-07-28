using Domain.Invoices.Repository;
using Domain.Products;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carts.DeleteCart
{
    public record DeleteCartCommand(int Id) : IRequest<DeleteCartCommandResponce>;

    public record DeleteCartCommandResponce(int Id);

    public  class DeleteCartCommandHandler(ICartRepository repository) : IRequestHandler<DeleteCartCommand, DeleteCartCommandResponce>
    {
        public async Task<DeleteCartCommandResponce> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = repository.GetById(request.Id);
            if (cart == null)
              throw new Exception("cart not found");


            int id = request.Id;
            repository.Delete(id);

            return new DeleteCartCommandResponce(id);
        }
    }



}
