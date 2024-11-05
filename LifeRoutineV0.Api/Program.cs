using LifeRoutineV0.Api.Endpoints;
using LifeRoutineV0.Application.Handlers;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Infra.Context;
using LifeRoutineV0.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpJsonOptions
    (x=> x.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LifeRoutineV0DbContext>
            (options => options.UseSqlServer(connectionString,
            b => b.MigrationsAssembly("LifeRoutineV0.Infra")));

builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
builder.Services.AddScoped<IAlimentoHandler, AlimentoHandler>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioHandler, UsuarioHandler>();
builder.Services.AddScoped<IFichaAlimentacaoRepository, FichaAlimentacaoRepository>();
builder.Services.AddScoped<IFichaAlimentacaoHandler, FichaAlimentacaoHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.Run();
