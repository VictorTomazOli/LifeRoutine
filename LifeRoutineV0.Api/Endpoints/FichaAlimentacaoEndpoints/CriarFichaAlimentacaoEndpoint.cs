using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class CriarFichaAlimentacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Ficha Alimentação: Criar ficha alimentação")
            .WithSummary("Cria uma nova ficha de alimentação")
            .Produces<Response<FichaAlimentacao?>>();

    public static async Task<IResult> HandleAsync(IFichaAlimentacaoHandler handler)
    {
        var request = new CriarFichaAlimentacaoRequest
        {
            UserId = 1
        };

        var result = await handler.CriarAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}",result) : TypedResults.BadRequest(result);
    }
}
