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
    public record DeleteProductCommand(int id) : IRequest<DeleteProductCommandResponse>;


    public record DeleteProductCommandResponse(int id);

    public class DeleteProductCommandHandler(IProductRepository repository,IVariationRepository variationRepository) : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           
            var product = repository.GetById(request.id);
            if(product == null)
            {
                throw new Exception("this product is in use");
            }
            var exist = await variationRepository.CheckExist(request.id);
            if (exist)
                throw new Exception("this category is in use");

            else
            {
                repository.Delete(request.id);
                return new DeleteProductCommandResponse(request.id);
            }
        }
    }
}
