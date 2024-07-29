using MediatR;

namespace Application.Categorys.GetCatrgory
{
    public record GetCategoryQuery(int Id) : IRequest<GetCategoryQueryResponse?>;

}
