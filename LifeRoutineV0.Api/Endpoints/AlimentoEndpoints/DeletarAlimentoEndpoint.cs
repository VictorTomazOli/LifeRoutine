using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;

public class DeletarAlimentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:int}", HandleAsync)
            .WithName("Alimento: Deletar alimento")
            .WithSummary("Deleta um alimento da lista")
            .Produces<Response<Alimento?>>();

    public static async Task<IResult> HandleAsync(int id,
        IAlimentoHandler handler)
    {
        var request = new DeletarAlimentoRequest
        {
            Id = id
        };

        var result = await handler.DeletarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}