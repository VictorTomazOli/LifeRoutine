using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.ContaRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;

public class LoginUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
         => app.MapPost("/login", HandleAsync)
             .WithName("Usuario: Logar usuario")
             .WithSummary("Faz o login de um usuario")
             .AllowAnonymous()
             .Produces<Response<string?>>();

    public static async Task<IResult> HandleAsync(LoginContaRequest request, IUsuarioHandler handler)
    {
        var result = await handler.LoginAsync(request);
        return result.IsSuccess ? TypedResults.Created("", result) : TypedResults.BadRequest(result);
    }
}