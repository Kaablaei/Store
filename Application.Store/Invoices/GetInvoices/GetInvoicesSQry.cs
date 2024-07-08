using Application.Products.GetProducts;
using Domain.Invoices;
using Domain.Invoices.Repository;
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
    public record GetInvoicesSQry(int PageNo, int PageSize) :IRequest<ReadOnlyCollection<GetInvoiceSQueryResponse>> { }
    
    public record GetInvoiceSQueryResponse(int id ,decimal Price)
    {
        public static explicit operator GetInvoiceSQueryResponse(Invoice invoice)

        {

            return new GetInvoiceSQueryResponse(invoice.Id, invoice.TotalPrice);
        }
    }





    public class GetInvoiceHandler : IRequestHandler<GetInvoicesSQry,IReadOnlyCollection<GetInvoiceSQueryResponse>>
    {
        private IInvoiveRepository _repo;
        public GetInvoiceHandler(IInvoiveRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<IReadOnlyCollection<GetInvoiceSQueryResponse>> Handle(GetInvoicesSQry request, CancellationToken cancellationToken)
        {


            var invoice = _repo.GetPaged(request.PageNo, request.PageSize);
            return [.. invoice.Select(p => (GetInvoiceSQueryResponse)p)];
        }
    }

}
