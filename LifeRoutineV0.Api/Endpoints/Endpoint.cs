using LifeRoutineV0.Api.Endpoints.AlimentoEndpoints;
using LifeRoutineV0.Api.Endpoints.FichaAlimentacaoEndpoints;
using LifeRoutineV0.Api.Endpoints.UsuarioEndpoints;
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

        endpoint.MapGroup("v1/ficha_alimentacao")
            .WithTags("Ficha Alimentação")
            .MapEndpoint<AdicionarRefeicaoFichaEndpoint>()
            .MapEndpoint<AtualizarRefeicaoFichaEndpoint>()
            .MapEndpoint<CriarFichaAlimentacaoEndpoint>()
            .MapEndpoint<DeletarFichaAlimentacaoEndpoint>()
            .MapEndpoint<ListarFichaAlimentacaoEndpoint>()
            .MapEndpoint<ListarRefeicaoFichaEndpoint>()
            .MapEndpoint<ListarRefeicaoPorTempoFichaEndpoint>()
            .MapEndpoint<RemoverRefeicaoFichaEndpoint>();

        endpoint.MapGroup("v1/usuarios")
            .WithTags("Usuários")
            .MapEndpoint<AtualizarSenhaUsuarioEndpoint>()
            .MapEndpoint<AtualizarUsuarioEndpoint>()
            .MapEndpoint<DeletarUsuarioEndpoint>()
            .MapEndpoint<ListarUsuarioEndpoint>();
    }

    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}