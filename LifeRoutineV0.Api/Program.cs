using LifeRoutineV0.Api.Endpoints;
using LifeRoutineV0.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AdicionarConfiguracao();
builder.AdicionarDocumentacao();
builder.AdicionarHttpConfigration();
builder.ConfigurarAuthenticacaoAutorizacao();
builder.AdicionarDbContext();
builder.AdicionarServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AdicionarSwagger();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();
