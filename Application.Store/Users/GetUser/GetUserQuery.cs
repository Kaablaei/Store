using Application.Users.GetAll;
using Domain.Users;
using Domain.Users.Repository;
using MediatR;
using System.Drawing;

namespace Application.Users.Get
{
    public record GetUserQuery(int Id):IRequest<GetUserQueryResponse>;


    public record GetUserQueryResponse(int Id);




    public record GetUserQueryHamdler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private IUserReopsitory _repo;
        public GetUserQueryHamdler(IUserReopsitory Repo)
        {
            _repo = Repo;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _repo.GetById(request.Id);

            return new GetUserQueryResponse(user.Id);
        }
    }



}
