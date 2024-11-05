﻿using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.UsuarioRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;

public class DeletarUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:int}", HandleAsync)
            .WithName("Usuario: Deletar usuário")
            .WithSummary("Deleta um usuário existente")
            .Produces<Response<Usuario?>>();

    public static async Task<IResult> HandleAsync(int id, IUsuarioHandler handler)
    {
        var request = new DeletarUsuarioRequest
        {
            UserId = id
        };

        var result = await handler.DeletarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}