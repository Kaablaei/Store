using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();

