using Application.Products.DeletProduct;
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


    public class DeleteCategoryCommandHandler(IProductRepository repository) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponce>
    {
        public async Task<DeleteCategoryCommandResponce> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var Categoty = repository.GetById(request.Id);
            if (Categoty == null)
            {
                throw new NullReferenceException(nameof(request.Id));
            }
            else
            {
                int id = request.Id;
                repository.Delete(id);

                return new DeleteCategoryCommandResponce(id);
            }
        }
    }
}
