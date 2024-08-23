using API.DTOs.Account;
using FluentAssertions;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Domain.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IntegrationTests.Fixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;
using AutoFixture;
using IdentityModel.Client;

namespace IntegrationTests.AccountingTest
{

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                Console.WriteLine("Configuring WebHost...");

                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                    var userManager = scopedServices.GetRequiredService<UserManager<User>>();
                    db.Database.EnsureCreated();

                    // Seed the data
                    SeedData(userManager).Wait();
                }
            });
        }

        private async Task SeedData(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "testuserforLogin",
                    Email = "testuser@example.com",
                    PhoneNumber = "090333589442",
                    Family = "UserFamily"

                };

                await userManager.CreateAsync(user, "Test@123");
            }
        }

    }

    public class AccountControllerTest : IClassFixture<CustomWebApplicationFactory<TestApi.Program>>
    {
        private readonly HttpClient _client;
        private readonly UserManager<User> _userManager;
        private readonly AutoFixture.Fixture _fixture;
        public AccountControllerTest(CustomWebApplicationFactory<TestApi.Program> factory)
        {
            HttpClient httpClient = factory.CreateClient();
            _client = httpClient;
            var scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var services = scope.ServiceProvider;
            _fixture = new AutoFixture.Fixture();
            _userManager = services.GetRequiredService<UserManager<User>>();
        }
        [Fact]
        public async Task Register_Should_Return_Ok_When_Valid_Data()
        {
            // Arrange
            var model = _fixture.Build<RegisterViewModel>()
                .With(p => p.Email, "user@e123xsample.com")
                .With(p => p.Password, "Aa123456")
                .With(p => p.RePassword, "Aa123456")
                .With(p => p.Phone, "090333589442")
                .Create();



            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act

            var response = await _client.PostAsync("/api/account/register", content);

            // Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Register_Should_Return_BadRequest_When_Model_Is_Not_Walid()
        {
            // Arrange
            var model = _fixture.Build<RegisterViewModel>()
                .With(p => p.Email, "test")
                .With(p => p.Password, "b")
                .With(p => p.RePassword, "a")
                .With(p => p.Phone, "slam")
                .Create();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            // Act

            var response = await _client.PostAsync("/api/account/register", content);

            // Assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Login_Should_Return_OK_When_Valid_Credentials()
        {
            // Arrange
            var loginModel = new LoginViewModel
            {
                 Usename = "testuserforLogin",
                Password = "Test@123"
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/account/login", content);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNullOrEmpty();


        }

        [Fact]
        public async Task Login_Should_Return_BadRequest_When_NotValid_Credentials()
        {
            // Arrange
            var loginModel = new LoginViewModel
            {
                Usename = "t",
                Password = "Test@123"
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/account/login", content);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNullOrEmpty();


        }


    }
}
