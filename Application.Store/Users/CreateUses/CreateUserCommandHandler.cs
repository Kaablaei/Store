using Application.Products.CreateProduct;
using Domain.Products.Repository;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users.Repository;
using Domain.Users;
using Infrastructure;
using API.OutBox;
using Newtonsoft.Json;

namespace Application.Users.Create
{

    public class CrateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserReopsitory _repository;
        private readonly ApplicationDbContext _context;

        public CrateUserCommandHandler(IUserReopsitory repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.name, request.family, request.phone, request.email);
            var id = _repository.Create(user);

            var outboxMessage = new OutboxMessage
            {
                Id = Guid.NewGuid(),
                AggregateId = user.Id.ToString(),
                EventType = "UserRegistered",
                Payload = JsonConvert.SerializeObject(user),
                CreatedAt = DateTime.UtcNow,
                Processed = false
            };

            _context.OutboxMessages.Add(outboxMessage);
            await _context.SaveChangesAsync();

            return new CreateUserCommandResponse(id);
        }
    }

}
