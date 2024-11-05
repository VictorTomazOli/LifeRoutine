using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.UsuarioRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;

public class AtualizarUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/", HandleAsync)
            .WithName("Usuario: Atualizar usuário")
            .WithSummary("Atualiza um usuário existente")
            .Produces<Response<Usuario?>>();

    public static async Task<IResult> HandleAsync(AtualizarUsuarioRequest request, IUsuarioHandler handler)
    {
        var result = await handler.AtualizarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}