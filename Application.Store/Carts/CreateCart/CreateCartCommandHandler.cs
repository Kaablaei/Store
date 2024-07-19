﻿using MediatR;
using Domain.Invoices.Repository;
using Domain.Invoices;
using Domain.Users.Repository;
using Domain.Products.Repository;
using Domain.Users;

namespace Application.Carts.CreateCart
{
    public class CreateCartCommandHandler(ICratRepository repository, IUserReopsitory userReopsitory, IVariationRepository variationRepository) : IRequestHandler<CreateCartCommend, CreateCartCommandResponse>
    {
        public async Task<CreateCartCommandResponse> Handle(CreateCartCommend request, CancellationToken cancellationToken)
        {

            var user = userReopsitory.GetById(request.userid);

            if (user == null)
            {
                throw new NullReferenceException(nameof(request.userid));
            }


            var variation = variationRepository.GetById(request.validationid);

            if (variation == null)
            {
                throw new NullReferenceException(nameof(request.validationid));
            }



            var cart = CartOrInvoiceDtail.Create(request.userid, request.validationid, request.price, request.saleprice);

            var id = repository.Create(cart);



            return new CreateCartCommandResponse(id);

        }
    }


}
