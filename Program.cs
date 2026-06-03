using FilmesApi.Data;
using FilmesAPI.Authorization;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

// 1. Configurações de Banco de Dados
builder.Services.AddDbContext<FilmeContext>(options => options.
                UseLazyLoadingProxies().UseMySql
                        (connectionString, ServerVersion.AutoDetect(connectionString)));

// 2. Mapeamentos
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 3. Configurações de Identidade 
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<FilmeContext>()
                .AddDefaultTokenProviders();

// 4. Seus Serviços Customizados 
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

// 5. Configurações de Autenticação e Autorização
builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

builder.Services.AddAuthorization(options => options.AddPolicy("IdadeMinima", policy =>
                                policy.AddRequirements(new IdadeMinima(18)) ));

// 6. Configurações Web e API
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddOpenApi();

var app = builder.Build();

// ==========================================
// PIPELINE DE MIDDLEWARES 
// ==========================================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
// PRIMEIRO: Descobre QUEM é o usuário 
app.UseAuthentication();
// SEGUNDO: Valida O QUE o usuário pode fazer 
app.UseAuthorization();
app.MapControllers();
app.Run();