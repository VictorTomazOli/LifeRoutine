﻿using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.UsuarioRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;

public class ListarUsuarioEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:int}", HandleAsync)
            .WithName("Usuario: Listar usuário")
            .WithSummary("Lista as informações de um usuário existente")
            .Produces<Response<Usuario?>>();

    public static async Task<IResult> HandleAsync(int id, IUsuarioHandler handler)
    {
        var request = new ListarUsuarioRequest 
        {
            UserId = id 
        };

        var result = await handler.ListarAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}