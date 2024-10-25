using LifeRoutineV0.Application.Handlers;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Infra.Context;
using LifeRoutineV0.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LifeRoutineV0DbContext>
            (options => options.UseSqlServer(connectionString,
            b => b.MigrationsAssembly("LifeRoutineV0.Infra")));

builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
builder.Services.AddScoped<IAlimentoHandler, AlimentoHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", teste2);
app.MapPost("/", teste);

async Task<IResult> teste(IAlimentoHandler handler, CriarAlimentoRequest request)
{
    var result = await handler.CriarAsync(request);
    return result.IsSuccess ? TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
}

async Task<IResult> teste2(IAlimentoHandler handler, [FromQuery]int pageNumber, [FromQuery]int pageSize)
{
    var request = new ListarAlimentoRequest { PageNumber = pageNumber , PageSize = pageNumber};
    var result = await handler.ListarAsync(request);
    return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.Run();
