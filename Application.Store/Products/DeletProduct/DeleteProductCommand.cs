using Application.Products.CreateProduct;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.DeletProduct
{
    public record DeleteProductCommand(int Id) : IRequest<DeleteProductCommandResponse>;


    public record DeleteProductCommandResponse(int Id);

    public class DeleteProductCommandHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            repository.Delete(id);

            return new DeleteProductCommandResponse(id);

        }
    }
}
