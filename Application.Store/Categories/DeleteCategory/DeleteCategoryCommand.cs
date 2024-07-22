using Application.Products.DeletProduct;
using Domain.Products;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest<DeleteCategoryCommandResponce>;

    public record DeleteCategoryCommandResponce(int Id);


    public class DeleteCategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponce>
    {
        public async Task<DeleteCategoryCommandResponce> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = repository.GetById(request.Id);
            if (category == null)
                throw new NullReferenceException(nameof(request.Id));

            int id = request.Id;
            repository.Delete(id);

            return new DeleteCategoryCommandResponce(id);
        }
    }
}
