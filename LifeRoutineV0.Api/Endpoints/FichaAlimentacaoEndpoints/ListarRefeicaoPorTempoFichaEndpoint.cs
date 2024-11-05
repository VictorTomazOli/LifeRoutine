using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class ListarRefeicaoPorTempoFichaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:int}/refeicao", HandleAsync)
            .WithName("Ficha Alimentação: Listar refeições por tempo")
            .WithSummary("Lista as refeições de uma ficha de alimentação")
            .Produces<PagedResponse<List<Refeicao>?>>();

    public static async Task<IResult> HandleAsync(int id,[FromQuery] int pageSize,
        [FromQuery] int pageNumber, IFichaAlimentacaoHandler handler)
    {
        var request = new ListarRefeicaoPorTempoRequest
        {
            UserId = 1,
            FichaId = id,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.ListarRefeicaoPorTempoAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
