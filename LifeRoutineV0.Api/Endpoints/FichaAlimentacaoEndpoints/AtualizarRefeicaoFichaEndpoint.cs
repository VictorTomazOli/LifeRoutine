using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.Services;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class AtualizarRefeicaoFichaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:int}/refeicao/{refeicaoId:int}", HandleAsync)
            .WithName("Ficha Alimentação: Atualizar refeição")
            .WithSummary("Atualizar uma refeição da ficha de alimentação")
            .Produces<PagedResponse<FichaAlimentacao?>>();

    public static async Task<IResult> HandleAsync(int id, int refeicaoId, AtualizarRefeicaoNaFichaRequest request,
        IFichaAlimentacaoHandler handler, IUsuarioContextService contextService)
    {
        var userId = contextService.GetUserId();

        request.UserId = userId;
        request.FichaId = id;
        request.RefeicaoId = refeicaoId;

        var result = await handler.AtualizarRefeicaoNaFichaAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
