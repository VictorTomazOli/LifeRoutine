using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class AdicionarRefeicaoFichaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id:int}/refeicao", HandleAsync)
            .WithName("Ficha Alimentação: Adicionar refeição")
            .WithSummary("Adiciona uma nova refeição a ficha de alimentação")
            .Produces<Response<Refeicao?>>();

    public static async Task<IResult> HandleAsync(int id, AdicionarRefeicaoNaFichaRequest request,
        IFichaAlimentacaoHandler handler)
    {
        request.UserId = 1;
        request.FichaId = id;

        var result = await handler.AdicionarRefeicaoNaFichaAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}
