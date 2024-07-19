using Application.Products.GetProducts;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.GetInvoices
{
    public record GetInvoicesQuery(int PageNo, int PageSize) :IRequest<ReadOnlyCollection<GetInvoiceSQueryResponse>> { }

}
