
using Application.Categorys.GetCatrgorys;
using Domain.Products;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Application;
using Infrastructure;
using Domain.Users.Repository;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using API.Handler;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            

            builder.Services.ConfigureApplicationLayer(builder.Configuration);
            builder.Services.ConfigureInfrastructureLayer(builder.Configuration);
            //


            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseAuthorization();

            app.Run();
        }
    }
}
