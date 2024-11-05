using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.UsuarioRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;

public class AtualizarSenhaUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/senha", HandleAsync)
            .WithName("Usuario: Atualizar senha usuário")
            .WithSummary("Atualiza a senha de um usuário")
            .Produces<Response<Usuario?>>();

    public static async Task<IResult> HandleAsync(AtualizarSenhaUsuarioRequest request, IUsuarioHandler handler)
    {
        var result = await handler.AtualizarSenhaAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}