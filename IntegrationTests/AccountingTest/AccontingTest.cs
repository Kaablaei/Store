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

namespace IntegrationTests.AccountingTest
{

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
               
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

                
                    db.Database.EnsureCreated();

                    
                }
            });
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
            var model = _fixture.Build<RegisterViewModel>().Create();

        // Arrange
        //var registerModel = new RegisterViewModel
        //    {
        //        Email = "user@e123xsample.com",
        //        Name = "Alimissdhzjbsads",
        //        Family = "UserFamily",
        //        Phone = "090333589442",
        //        Password = "Aa123456.",
        //      RePassword = "Aa123456."
        //};

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
           
            var response = await _client.PostAsync("/api/account/register", content);

            // Assert
        
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().NotBeNullOrEmpty();
        }


        [Fact]
        public async Task Login_Should_Return_Token_When_Valid_Credentials()
        {
            // Arrange
            var user = new User
            {
                UserName = "user",
                Family = "UserFamily",
                Email = "user@example.com",
                PhoneNumber = "1234567890"
            };

            var password = "Test@123";
            await _userManager.CreateAsync(user, password);

            var loginModel = new LoginViewModel
            {
                Usename = "user",
                Password = password
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/account/login", content);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("Token");
        }
    }
}
