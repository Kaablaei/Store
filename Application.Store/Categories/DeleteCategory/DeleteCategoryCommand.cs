﻿using Application.Products.DeletProduct;
using Domain.Products;
using Domain.Products.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest<DeleteCategoryCommandResponce>;

    public record DeleteCategoryCommandResponce(int Id);


    public class DeleteCategoryCommandHandler(ICategoryRepository repository,IProductRepository productRepository) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponce>
    {
        public async Task<DeleteCategoryCommandResponce> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = repository.GetById(request.Id);
            if (category == null)
            {
                return null;
                throw new Exception("category not found");
            }
                

            var exist =await  productRepository.CheckExist(request.Id);
            if (exist)
                return null;


            repository.Delete(request.Id);

            return new DeleteCategoryCommandResponce(request.Id);
        }
    }
}
