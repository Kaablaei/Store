using Application.Categorys.CreateCategory;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Repositories;
using IntegrationTests.Fixture;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.CategoryTests
{
    public partial class CreateCategoryCommandHandlerTests : IClassFixture<DbContextFixture>
    {
        private readonly DbContextFixture _fixture;

        private readonly IThirdParty _thirdParty;


        public CreateCategoryCommandHandlerTests(DbContextFixture fixture)
        {
            _fixture = fixture;
            _thirdParty = NSubstitute.Substitute.For<IThirdParty>();
        }


        [Fact]
        public async Task Handle_Should_Create_Category()
        {

            //arrange
            var dbName = Guid.NewGuid().ToString();
            var repo = new CategoryRepositories(_fixture.BuildDbContext(dbName));

            var handler = new CreateCategoryCommandHandler(repo, _thirdParty);
            _thirdParty.SendSMS(Arg.Any<int>(), CancellationToken.None).Returns(3);
            //act



            var command = new CreateCategoryCommand("Mobile");
            var result = await handler.Handle(command, CancellationToken.None);



            //assert


            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);

            var category = repo.GetById(result.Id);

            category.Should().NotBeNull();
            category?.Name.Should().Be(command.name);



        }
    }
}
