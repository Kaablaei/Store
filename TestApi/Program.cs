
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using API.OptionSetup;
using Infrastructure.Authentication;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            builder.Services.ConfigureApplicationLayer(builder.Configuration);
            builder.Services.ConfigureInfrastructureLayer(builder.Configuration);

            builder.Services.AddIdentity<User, IdentityRole<int>>(op =>
            {
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            builder.Services.AddSingleton<JWTProvide>();
            builder.Services.ConfigureOptions<JwtOptionSetup>();
            builder.Services.ConfigureOptions<JwtBeareOptionSetup>();
                




            var app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }



}



