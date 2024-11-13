using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.Services;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class CriarFichaAlimentacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Ficha Alimentação: Criar ficha alimentação")
            .WithSummary("Cria uma nova ficha de alimentação")
            .Produces<Response<FichaAlimentacao?>>();

    public static async Task<IResult> HandleAsync(IFichaAlimentacaoHandler handler, IUsuarioContextService contextService)
    {
        var userId = contextService.GetUserId();

        var request = new CriarFichaAlimentacaoRequest
        {
            UserId = userId
        };

        var result = await handler.CriarAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}",result) : TypedResults.BadRequest(result);
    }
}
