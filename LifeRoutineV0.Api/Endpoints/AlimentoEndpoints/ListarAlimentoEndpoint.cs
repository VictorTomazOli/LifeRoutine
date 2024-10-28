using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;

public class ListarAlimentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Alimento: Listar alimentos")
            .WithSummary("Lista todos os alimentos")
            .Produces<PagedResponse<List<Alimento>?>>();

    public static async Task<IResult> HandleAsync([FromQuery] int pageSize,
        [FromQuery] int pageNumber, IAlimentoHandler handler)
    {
        var request = new ListarAlimentoRequest
        {
            PageSize = pageSize,
            PageNumber = pageNumber
        };

        var result = await handler.ListarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}