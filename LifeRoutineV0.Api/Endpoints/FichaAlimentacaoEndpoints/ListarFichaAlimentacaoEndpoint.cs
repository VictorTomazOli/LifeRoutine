using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class ListarFichaAlimentacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:int}", HandleAsync)
            .WithName("Ficha Alimentação: Listar ficha alimentação")
            .WithSummary("Lista a ficha de alimentação do usuário")
            .Produces<PagedResponse<FichaAlimentacao?>>();

    public static async Task<IResult> HandleAsync(int id, [FromQuery] int pageSize,
        [FromQuery] int pageNumber, IFichaAlimentacaoHandler handler, IUsuarioContextService contextService)
    {
        var userId = contextService.GetUserId();

        var request = new ListarFichaAlimentacaoRequest
        {
            UserId = userId,
            Id = id,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.ListarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
