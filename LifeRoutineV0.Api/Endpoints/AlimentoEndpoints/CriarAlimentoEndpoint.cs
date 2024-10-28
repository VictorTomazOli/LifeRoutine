using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;

public class CriarAlimentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Alimento: Criar alimento")
            .WithSummary("Cria um alimento")
            .Produces<Response<Alimento?>>();

    public static async Task<IResult> HandleAsync(CriarAlimentoRequest request, IAlimentoHandler handler)
    {
        var result = await handler.CriarAsync(request);
        return result.IsSuccess ? 
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}