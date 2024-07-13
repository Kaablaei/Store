using Domain.Products;
using Domain.Products.Repository;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Integrated_Test
{
    public class Class1
    {
        [Fact]
        public void AddCategoryTest()
        {
            //arginr
            Category category = Category.Create("لوازم خانگی ");

            //var categort = new Category()
            //{
            //    Id = 1,
            //    Name = "لوازم خانگی",
            //    CratetdAgent = "1",
            //    CreatedById = 1,
            //    CreatedIP = "1",
            //    CreateOn = DateTime.UtcNow,
            //    ModifiedById = 1,
            //    ModifiedOn = DateTime.UtcNow,
            //    ModifyAgent = "1",
            //    ModifyIP = "1",
            //    Version = 1,

            //};

            //assert
            ApplicationDbContext Db = new ApplicationDbContext();
            ICategoryRepository categoryRepository = new CategoryRepositories(Db);


            //act
            categoryRepository.Create(category);

            categoryRepository.Should();
        }

    }
}
