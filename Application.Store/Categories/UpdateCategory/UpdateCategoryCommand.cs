using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.UpdateCategory
{
    public record UpdateCategoryCommand(int Id, string Name) : IRequest<UpdateCategoryCommandResponse>;

    public record UpdateCategoryCommandResponse(int Id);


    public class UpdateCategoryCommandHandle(ICategoryRepository repository) : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = repository.GetById(request.Id);

            if(category == null)
            {
                throw new NullReferenceException(nameof(request.Id));
            }

            category.Name = request.Name;

            repository.Update(category);

            return new UpdateCategoryCommandResponse(category.Id);
        }
    }
}
