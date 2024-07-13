using Domain.Products;
using Domain.Products.Repository;
using MediatR;

namespace Application.Categorys.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository repository, IThirdParty thirdParty) : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var categury = Category.Create(request.name);
            var id = repository.Create(categury);
            var sendId=await thirdParty.SendSMS(id, cancellationToken);

            return new CreateCategoryCommandResponse(id);
        }

       
    }

    public class ThirdParty : IThirdParty
    {
        public async Task<long> SendSMS(int id, CancellationToken cancellationToken)
        {
            //Call api....
            return 1;

        }
    }


}
