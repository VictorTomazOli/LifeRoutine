using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;

public class ListarPorGrupoAlimentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/grupo", HandleAsync)
            .WithName("Alimento: Listar alimentos grupo")
            .WithSummary("Lista todos os alimentos de um grupo alimentar")
            .Produces<PagedResponse<List<Alimento>?>>();

    public static async Task<IResult> HandleAsync([FromQuery] int grupoAlimentar,[FromQuery] int pageSize,
        [FromQuery] int pageNumber, IAlimentoHandler handler)
    {
        var request = new ListarPorGrupoAlimentoRequest
        {
            PageSize = pageSize,
            PageNumber = pageNumber,
            GrupoAlimentar = grupoAlimentar
        };

        var result = await handler.ListarPorGrupoAlimentarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}