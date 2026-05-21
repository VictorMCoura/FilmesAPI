using FilmesApi.Data;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(options => options.
                UseLazyLoadingProxies().UseMySql
                        (connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserService>();

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<FilmeContext>()
                .AddDefaultTokenProviders();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
