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
    public class CreateProductCommandHandler(IProductRepository repository, ICategoryRepository categoryRepository) : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepository.GetById(request.CategoryId);

            if (category == null)
            {
                throw new Exception("category not found");
            }

            var product = Product.Create(" a", request.Title,  request.CategoryId);
            var id = repository.Create(product);

            return new CreateProductCommandResponse(id);
        }
    }
}
