using Application.Products.GetProducts;
using Domain.Products;
using Domain.Users;
using Domain.Users.Repository;
using MediatR;
using System.Collections.ObjectModel;

namespace Application.Users.GetAll
{
    public record GetUsersQuery(int PageNo, int PageSize) : IRequest<ReadOnlyCollection<GetUsersQueryResponse>>;


    public record GetUsersQueryResponse(int Id, string email, string name)
    {
        public static explicit operator GetUsersQueryResponse(User product)

        {

            return new GetUsersQueryResponse(product.Id, product.Email, product.Name);
        }
    }


    public class GetUserSHandler : IRequestHandler<GetUsersQuery, IReadOnlyCollection<GetUsersQueryResponse>>
    {
        private IUserReopsitory _repo;
        public GetUserSHandler(IUserReopsitory Repo)
        {
            _repo = Repo;
        }
        public async Task<IReadOnlyCollection<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {

            var users = _repo.GetPaged(request.PageNo, request.PageSize);

            return [.. users.Select(p => (GetUsersQueryResponse)p)];

        }
    }

}
