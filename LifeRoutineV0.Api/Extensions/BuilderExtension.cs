using LifeRoutineV0.Application.Handlers;
using LifeRoutineV0.Domain;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Domain.Services;
using LifeRoutineV0.Infra.Context;
using LifeRoutineV0.Infra.Repositories;
using LifeRoutineV0.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace LifeRoutineV0.Api.Extensions;

public static class BuilderExtension
{
    public static void AdicionarHttpConfigration(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureHttpJsonOptions
            (x => x.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    }

    public static void AdicionarDocumentacao(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void AdicionarConfiguracao(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey") ?? string.Empty;
    }

    public static void AdicionarDbContext(this WebApplicationBuilder builder)
    {
        var connectionString = Configuration.ConnectionString;
        builder.Services.AddDbContext<LifeRoutineV0DbContext>
                    (options => options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("LifeRoutineV0.Infra")));
    }

    public static void AdicionarServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
        builder.Services.AddScoped<IAlimentoHandler, AlimentoHandler>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<IUsuarioHandler, UsuarioHandler>();
        builder.Services.AddScoped<IFichaAlimentacaoRepository, FichaAlimentacaoRepository>();
        builder.Services.AddScoped<IFichaAlimentacaoHandler, FichaAlimentacaoHandler>();
        builder.Services.AddTransient<ITokenService, TokenService>();
        builder.Services.AddScoped<IUsuarioContextService, UsuarioContextService>();
    }

    public static void ConfigurarAuthenticacaoAutorizacao(this WebApplicationBuilder builder)
    {
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
        )
            .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }
        );

        builder.Services.AddAuthorization(
            );
    }
}