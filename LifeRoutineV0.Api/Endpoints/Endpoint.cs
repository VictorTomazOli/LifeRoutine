using LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;
using LifeRoutineV0.Api.Interfaces;

namespace LifeRoutineV0.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("");

        endpoint.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoint.MapGroup("v1/alimentos")
            .WithTags("Alimentos")
            .MapEndpoint<AtualizarAlimentoEndpoint>()
            .MapEndpoint<CriarAlimentoEndpoint>()
            .MapEndpoint<DeletarAlimentoEndpoint>()
            .MapEndpoint<ListarAlimentoEndpoint>()
            .MapEndpoint<ListarPorGrupoAlimentoEndpoint>();
    }

    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}