using Domain.Users.Repository;
using MediatR;

namespace Application.Users.Get
{
    public class GetUserQueryHamdler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private IUserReopsitory _repo;
        public GetUserQueryHamdler(IUserReopsitory Repo)
        {
            _repo = Repo;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _repo.GetById(request.Id);
            if (user == null)
            {
                return null;
            }
            return  (GetUserQueryResponse)user;
        }

    }



}
