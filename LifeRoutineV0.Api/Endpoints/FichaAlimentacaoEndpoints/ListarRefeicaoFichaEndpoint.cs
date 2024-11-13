using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.Services;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class ListarRefeicaoFichaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:int}/refeicao/{refeicaoId:int}", HandleAsync)
            .WithName("Ficha Alimentação: Listar refeição")
            .WithSummary("Lista uma refeição de uma ficha de alimentação")
            .Produces<Response<FichaAlimentacao?>>();

    public static async Task<IResult> HandleAsync(int id, int refeicaoId, 
        IFichaAlimentacaoHandler handler, IUsuarioContextService contextService)
    {
        var userId = contextService.GetUserId();

        var request = new ListarRefeicaoNaFichaRequest
        {
            UserId = userId,
            FichaId = id,
            RefeicaoId = refeicaoId
        };

        var result = await handler.ListarRefeicaoAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
