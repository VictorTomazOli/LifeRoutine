using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;

public class AtualizarAlimentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:int}", HandleAsync)
            .WithName("Alimento: Atualizar alimento")
            .WithSummary("Atualizar um alimento da lista")
            .Produces<Response<Alimento?>>();

    public static async Task<IResult> HandleAsync(int id, AtualizarAlimentoRequest request,
        IAlimentoHandler handler)
    {
        request.Id = id;

        var result = await handler.AtualizarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}