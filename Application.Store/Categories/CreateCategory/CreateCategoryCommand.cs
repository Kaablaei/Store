using MediatR;

namespace Application.Categorys.CreateCategory
{
    public record CreateCategoryCommand(string name ): IRequest<CreateCategoryCommandResponse>;


}
