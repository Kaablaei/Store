using Domain.Products;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create("", request.Title, request.Price, request.CategoryId);
            var id=repository.Create(product);
      
            return new CreateProductCommandResponse(id);
        }
    }
}
