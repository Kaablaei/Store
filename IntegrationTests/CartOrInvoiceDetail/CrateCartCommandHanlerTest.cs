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
            var Variationrepo = new VariationRepository(_fixture.BuildDbContext(dbName));
            var variation = Variation.Create(1,"red","2x larg",2.99m,10,1);
            Variationrepo.Create(variation);


            var handel = new CreateCartCommandHandler(repo, userrepo, Variationrepo);

            //act 
      
            var command = new CreateCartCommend(user.Id, variation.Id,6.99m,6.99m);

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
            var variationrepo = new VariationRepository(_fixture.BuildDbContext(dbName));
            var varidation = Variation.Create(1, "red", "2x larg", 2.99m, 10, 1);
           


            var handel = new CreateCartCommandHandler(repo, userrepo, variationrepo);

            //act 
         
            var command = new CreateCartCommend(user.Id, varidation.Id,6.99m,6.99m);

            
            Func<Task> act = async () => await handel.Handle(command, CancellationToken.None);

            //assert
            await act.Should().ThrowAsync<NullReferenceException>();


        }
    }
}
