using Application.Carts.CreateCart;
using Application.Users.Create;
using Domain.Products;
using Domain.Users;
using FluentAssertions;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.CartOrInvoiceDetail
{
    public class CrateCartCommandHanlerTest : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        public CrateCartCommandHanlerTest(DbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Handle_Should_Create_Cart()
        {

            //arrange
            string dbName = Guid.NewGuid().ToString();
            var repo = new CartRepository(_fixture.BuildDbContext(dbName));


            //aboutUser
            var userrepo = new UserRepositories(_fixture.BuildDbContext(dbName));
            
            var user = User.Create("عبدالله","عباسی","09033958337","a@.com");
            userrepo.Create(user);

            //aboutProduct 
            var productRepo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var product = Product.Create("25m56", "تیشرت آبی", 2500.99m, 22);
            productRepo.Create(product);


            var handel = new CreateCartCommandHandler(repo, userrepo, productRepo);

            //act 
      
            var command = new CreateCartCommend(user.Id,product.Id,6.99m,6.99m);

            var result = await handel.Handle(command, CancellationToken.None);

            //assert
            result.Should().NotBeNull();
            result.id.Should().BeGreaterThan(0);

            var cart = repo.GetById(result.id);
            cart.Should().NotBeNull();
            cart.Price.Should().Be(command.price);
            cart.UserId.Should().Be(command.userid);
           
            
        }

        [Fact]
        public async void Handler_Should_Throw_Exception_If_ProductOrUser_NotFound()
        {

            //arrange
            string dbName = Guid.NewGuid().ToString();
            var repo = new CartRepository(_fixture.BuildDbContext(dbName));


            //aboutUser
            var userrepo = new UserRepositories(_fixture.BuildDbContext(dbName));
            
            var user = User.Create("عبدالله","عباسی","09033958337","a@.com");
        

            //aboutProduct 
            var productRepo = new ProductRepositories(_fixture.BuildDbContext(dbName));
            var product = Product.Create("25m56", "تیشرت آبی", 2500.99m, 22);
           


            var handel = new CreateCartCommandHandler(repo, userrepo, productRepo);

            //act 
         
            var command = new CreateCartCommend(user.Id,product.Id,6.99m,6.99m);

            
            Func<Task> act = async () => await handel.Handle(command, CancellationToken.None);

            //assert
            await act.Should().ThrowAsync<NullReferenceException>();


        }
    }
}
