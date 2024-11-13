using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.Services;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class AdicionarRefeicaoFichaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id:int}/refeicao", HandleAsync)
            .WithName("Ficha Alimentação: Adicionar refeição")
            .WithSummary("Adiciona uma nova refeição a ficha de alimentação")
            .Produces<Response<Refeicao?>>();

    public static async Task<IResult> HandleAsync(int id, AdicionarRefeicaoNaFichaRequest request,
        IFichaAlimentacaoHandler handler, IUsuarioContextService contextService)
    {
        var userId = contextService.GetUserId();

        request.UserId = userId;
        request.FichaId = id;

        var result = await handler.AdicionarRefeicaoNaFichaAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}
