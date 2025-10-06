using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rastro.Application.Mappings;
using Rastro.Application.Services;
using Rastro.Domain.DTOs.ContasAPagar;
using Rastro.Domain.DTOs.Usuario;
using Rastro.Domain.Entities;
using Rastro.Domain.Interfaces.Account;
using Rastro.Domain.Interfaces.Repository;
using Rastro.Domain.Interfaces.Service;
using Rastro.Domain.Validators;
using Rastro.Infra.Context;
using Rastro.Infra.Identity;
using Rastro.Infra.Repository;
using Rastro.API.Mappings;
using System.Text;
using Rastro.Application.Dependencies;
using Rastro.Infra.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAuthenticate, AuthenticateService>(); // Por enquanto nao pretendo criar camada separada para autenticação
builder.Services.AddApplication().AddInfra(); // Adiciona as dependências da aplicação e infraestrutura

builder.Services.AddControllers();

// Configuração do JWT
var jwtSecret = builder.Configuration["JwtSettings:Secret"];
if (string.IsNullOrEmpty(jwtSecret))
{
    throw new InvalidOperationException("JWT secret key não configurada em JwtSettings:Secret no appsettings.json");
}

var key = Encoding.ASCII.GetBytes(jwtSecret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,

        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rastro API",
        Version = "v1",
        Description = "API para gerenciamento de contas a pagar e receber",
        Contact = new OpenApiContact
        {
            Name = "Suporte",
            Email = "suporte@rastro.com"
        }
    });

    // Configuração de autenticação JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando Bearer scheme.\r\n\r\n " +
                     "Digite seu token.\r\n\r\n" +
                     "Exemplo: '12345abcdef'"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configuração do DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly, 
                             typeof(ViewModelMappingProfile).Assembly);

// Configuração do FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateContasAPagarDTO>, CreateContasAPagarDTOValidator>();
builder.Services.AddScoped<IValidator<ContasAPagar>, ContasAPagarValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rastro API v1");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.DefaultModelsExpandDepth(-1); // Esconde os esquemas na parte inferior
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();





