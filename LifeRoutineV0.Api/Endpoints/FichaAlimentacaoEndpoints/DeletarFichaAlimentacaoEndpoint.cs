using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class DeletarFichaAlimentacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:int}", HandleAsync)
            .WithName("Ficha Alimentação: Deletar ficha alimentação")
            .WithSummary("Deleta a ficha de alimentação do usuário")
            .Produces<Response<Refeicao?>>();

    public static async Task<IResult> HandleAsync(int id, IFichaAlimentacaoHandler handler)
    {
        var request = new DeletarFichaAlimentacaoRequest
        {
            UserId = 1,
            Id = id
        };

        var result = await handler.DeletarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
