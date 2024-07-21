﻿using Application.Products.DeletProduct;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.UpdateProduct
{
    public  record UpdateProductCommand(int Id,string SKU , string Title  ,decimal Picter, int CategoryId ) : IRequest<UpdateProductCommandResponse>;
    public record UpdateProductCommandResponse(int Id);

    public  class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = repository.GetById(request.Id);
            product.SKU = request.SKU;
            product.Title = request.Title;
            product.Picter = request.Picter;
            product.CategoryId = request.CategoryId;
            repository.Update(product);

            return new UpdateProductCommandResponse(product.Id);
        }
    }
}

