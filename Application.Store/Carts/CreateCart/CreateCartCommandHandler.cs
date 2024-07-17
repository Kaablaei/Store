using MediatR;
using Domain.Invoices.Repository;
using Domain.Invoices;

namespace Application.Carts.CreateCart
{
    public class CreateCartCommandHandler(ICratRepository repository) : IRequestHandler<GetUserCartCommend, CreateCartCommandResponse>
    {
        public async Task<CreateCartCommandResponse> Handle(GetUserCartCommend request, CancellationToken cancellationToken)
        {
            var cart = CartOrInvoiceDtail.Create(request.userid, request.validationid, request.price, request.saleprice);

            var id = repository.Create(cart);



            return new CreateCartCommandResponse(id);

        }
    }


}
