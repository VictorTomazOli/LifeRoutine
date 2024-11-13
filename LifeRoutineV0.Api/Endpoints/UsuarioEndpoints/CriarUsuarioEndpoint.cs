using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.ContaRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;

public class CriarUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Usuario: Criar conta de usuario")
            .WithSummary("Cria a conta do usuario")
            .AllowAnonymous()
            .Produces<Response<Usuario?>>();

    public static async Task<IResult> HandleAsync(CriarContaRequest request, IUsuarioHandler handler)
    {
        var result = await handler.CriarAsync(request);
        return result.IsSuccess ?
            TypedResults.Created($"{result.Data?.Id}", result) : TypedResults.BadRequest(result);
    }
}
