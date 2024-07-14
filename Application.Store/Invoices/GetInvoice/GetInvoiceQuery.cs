using Application.Users.Get;
using Domain.Users;
using Domain.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Get
{
    public record GetInvoiceQuery(int Id) : IRequest<GetInvoiceQueryResponse>;

}
