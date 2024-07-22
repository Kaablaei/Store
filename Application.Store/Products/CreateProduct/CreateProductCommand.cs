using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Products.CreateProduct
{
    public record CreateProductCommand(string suk, string Title,  int CategoryId) : IRequest<CreateProductCommandResponse>;
}
