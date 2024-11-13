﻿using LifeRoutineV0.Api.Interfaces;
using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.Services;

namespace LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;

public class RemoverRefeicaoFichaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:int}/refeicao/{refeicaoId:int}", HandleAsync)
            .WithName("Ficha Alimentação: Deletar refeição")
            .WithSummary("Deleta uma refeição da ficha de alimentação")
            .Produces<Response<FichaAlimentacao?>>();

    public static async Task<IResult> HandleAsync(int id, int refeicaoId, IFichaAlimentacaoHandler handler,
        IUsuarioContextService contextService)
    {
        var userId = contextService.GetUserId();

        var request = new RemoverRefeicaoNaFichaRequest
        {
            UserId = userId,
            FichaId = id,
            RefeicaoId = refeicaoId
        };

        var result = await handler.RemoverRefeicaoNaFichaAsync(request);
        return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
    }
}
