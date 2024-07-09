using Application.Invoices.CreateInvoice;
using Domain.Invoices;
using Domain.Products;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.CreateCategory
{
    public record CreateCategoryCommand(string name ): IRequest<CreateCategoryCommandResponse>;
   public record CreateCategoryCommandResponse (int id);

    public class CreateCategoryHandler(ICategoryRepository repository) : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var categury = Category.Create(request.name);
            var id = repository.Create(categury);

            return new CreateCategoryCommandResponse(id);
        }
    }


}
