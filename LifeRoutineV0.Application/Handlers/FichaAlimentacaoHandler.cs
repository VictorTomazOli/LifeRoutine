using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Enums;
using LifeRoutineV0.Domain.Extensions;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace LifeRoutineV0.Application.Handlers;

public class FichaAlimentacaoHandler(IFichaAlimentacaoRepository repository) : IFichaAlimentacaoHandler
{
    public async Task<Response<Refeicao?>> AdicionarRefeicaoNaFichaAsync(AdicionarRefeicaoNaFichaRequest request)
    {
        try
        {
            var fichaAlimentacao = await repository.ListarPorIdAsync(request.FichaId);
            if (fichaAlimentacao is null)
                return new Response<Refeicao?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            var refeicao = new Refeicao(request.DataCriacao, request.Alimentos);

            fichaAlimentacao.AdicionarRefeicao(refeicao);
            
            await repository.AtualizarAsync(fichaAlimentacao);
            await repository.SalvarMudancasAsync();
            return new Response<Refeicao?>(refeicao, EStatusCode.Created, "Refeição criada com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Refeicao?>(null, EStatusCode.BadRequest, "Refeição já existe");
        }
        catch
        {
            return new Response<Refeicao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<FichaAlimentacao?>> AtualizarRefeicaoNaFichaAsync(AtualizarRefeicaoNaFichaRequest request)
    {
        try
        {
            var fichaAlimentacao = await repository.ListarPorIdAsync(request.FichaId, ["Refeicoes"]);
            if (fichaAlimentacao is null)
                return new Response<FichaAlimentacao?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            var refeicao = fichaAlimentacao.Refeicoes.FirstOrDefault(x => x.Id == request.RefeicaoId);
            if (refeicao is null)
                return new Response<FichaAlimentacao?>(null, EStatusCode.NotFound, "A refeição não foi encontrada");

            refeicao.AlterarRefeicao(request.DataCriacao, request.Alimentos);

            await repository.AtualizarAsync(fichaAlimentacao);
            await repository.SalvarMudancasAsync();
            return new Response<FichaAlimentacao?>(fichaAlimentacao, EStatusCode.Ok, "Refeição atualizada com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.BadRequest, $"Falha ao atualizar refeição da ficha - {ex.Message}");
        }
        catch
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<FichaAlimentacao?>> CriarAsync(CriarFichaAlimentacaoRequest request)
    {
        try
        {
            var usuario = await repository.ListarUsuario(request.UserId);
            if (usuario is null)
                return new Response<FichaAlimentacao?>(null, EStatusCode.NotFound, "O usuário não existe");

            var fichaAlimentacao = new FichaAlimentacao(usuario);
            
            await repository.CriarAsync(fichaAlimentacao);
            await repository.SalvarMudancasAsync();
            return new Response<FichaAlimentacao?>(fichaAlimentacao, EStatusCode.Created, "Ficha criada com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.BadRequest, "A ficha já existe");
        }
        catch
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<FichaAlimentacao?>> DeletarAsync(DeletarFichaAlimentacaoRequest request)
    {
        try
        {
            var fichaAlimentacao = await repository.ListarPorIdAsync(request.Id);
            if (fichaAlimentacao is null)
                return new Response<FichaAlimentacao?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            await repository.DeletarAsync(fichaAlimentacao);
            await repository.SalvarMudancasAsync();
            return new Response<FichaAlimentacao?>(null, EStatusCode.Ok, "Ficha de Alimentacao deletada com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.BadRequest, $"Falha ao deletar ficha - {ex.Message}");
        }
        catch
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<PagedResponse<FichaAlimentacao?>> ListarAsync(ListarFichaAlimentacaoRequest request)
    {
        try
        {
            var fichaAlimentacao = await repository.ListarPorIdAsNoTracking(request.Id, ["Refeicoes"]);
            if (fichaAlimentacao is null)
                return new PagedResponse<FichaAlimentacao?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            fichaAlimentacao.ListarRefeicoes(request.PageNumber, request.PageSize);

            return new PagedResponse<FichaAlimentacao?>(fichaAlimentacao, EStatusCode.Ok);
        }
        catch
        {
            return new PagedResponse<FichaAlimentacao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<Refeicao?>> ListarRefeicaoAsync(ListarRefeicaoNaFichaRequest request)
    {
        try
        {
            var fichaAlimentacao = await repository.
                    ListarPorIdAsNoTracking(request.FichaId, "Refeicoes", ["Alimentos"]);

            if (fichaAlimentacao is null)
                return new Response<Refeicao?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            var refeicao = fichaAlimentacao.Refeicoes.FirstOrDefault(x => x.Id == request.RefeicaoId);
            if (refeicao is null)
                return new Response<Refeicao?>(null, EStatusCode.NotFound, "A refeição não foi encontrada");

            return new Response<Refeicao?>(refeicao, EStatusCode.Ok);
        }
        catch
        {
            return new Response<Refeicao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<PagedResponse<List<Refeicao>?>> ListarRefeicaoPorTempoAsync(ListarRefeicaoPorTempoRequest request)
    {
        try
        {
            request.TempoInicial ??= DateTime.Now.DataInicial();
            request.TempoFinal ??= DateTime.Now.DataFinal();

            var fichaAlimentacao = await repository.ListarPorIdAsNoTracking(request.FichaId, "Refeicoes", ["Alimentos"]);

            if (fichaAlimentacao is null)
                return new PagedResponse<List<Refeicao>?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            var refeicoes = fichaAlimentacao.Refeicoes
                .Where(w => w.DataDeCriacao >= request.TempoInicial && w.DataDeCriacao <= request.TempoFinal)
                .OrderBy(o => o.DataDeCriacao)
                .Skip(request.PageNumber - 1 * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var count = refeicoes.Count;

            return new PagedResponse<List<Refeicao>?>(refeicoes, request.PageSize, request.PageNumber, count);
        }
        catch
        {
            return new PagedResponse<List<Refeicao>?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<FichaAlimentacao?>> RemoverRefeicaoNaFichaAsync(RemoverRefeicaoNaFichaRequest request)
    {
        try
        {
            var fichaAlimentacao = await repository.ListarPorIdAsync(request.FichaId, "Refeicoes", ["Alimentos"]);
            if (fichaAlimentacao is null)
                return new Response<FichaAlimentacao?>(null, EStatusCode.NotFound, "A ficha não foi encontrada");

            var refeicao = fichaAlimentacao.Refeicoes.FirstOrDefault(x => x.Id == request.RefeicaoId);
            if (refeicao is null)
                return new Response<FichaAlimentacao?>(null, EStatusCode.NotFound, "A refeição não foi encontrada");

            fichaAlimentacao.RemoverRefeicao(refeicao);

            await repository.AtualizarAsync(fichaAlimentacao);
            await repository.SalvarMudancasAsync();
            return new Response<FichaAlimentacao?>(null, EStatusCode.Ok, "A refeição foi removida com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.BadRequest, $"Falha ao remover refeição - {ex.Message}");
        }
        catch
        {
            return new Response<FichaAlimentacao?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}