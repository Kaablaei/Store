using Domain.Users.Repository;
using MediatR;

namespace Application.Users.GetAll
{
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
