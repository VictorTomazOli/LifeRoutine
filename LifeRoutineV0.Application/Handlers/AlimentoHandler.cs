using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Enums;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace LifeRoutineV0.Application.Handlers;

public class AlimentoHandler(IAlimentoRepository repository) : IAlimentoHandler
{
    public async Task<Response<Alimento?>> AtualizarAsync(AtualizarAlimentoRequest request)
    {
        try
        {
            var alimento = await repository.ListarPorIdAsync(request.Id);
            if (alimento is null)
                return new Response<Alimento?>(null, EStatusCode.NotFound, "O alimento não foi encontrado");

            alimento.AlterarAlimento(request.Nome, (EGrupoAlimentar)request.GrupoAlimentar);

            await repository.AtualizarAsync(alimento);
            await repository.SalvarMudancasAsync();
            return new Response<Alimento?>(alimento, EStatusCode.Ok, "Alimento foi atualizado com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<Alimento?>(null, EStatusCode.BadRequest, $"Falha ao atualizar alimento - {ex.Message}");
        }
        catch
        {
            return new Response<Alimento?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<Alimento?>> CriarAsync(CriarAlimentoRequest request)
    {
        try
        {
            var alimento = new Alimento(request.Nome, (EGrupoAlimentar)request.GrupoAlimentar);

            await repository.CriarAsync(alimento);
            
            await repository.SalvarMudancasAsync();
            return new Response<Alimento?>(alimento, EStatusCode.Created, "Alimento criado com sucesso");
        }
        catch(DbUpdateException)
        {
            return new Response<Alimento?>(null, EStatusCode.BadRequest, "Alimento já existe");
        }
        catch
        {
            return new Response<Alimento?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<Alimento?>> DeletarAsync(DeletarAlimentoRequest request)
    {
        try
        {
            var alimento = await repository.ListarPorIdAsync(request.Id);
            if (alimento is null)
                return new Response<Alimento?>(null, EStatusCode.NotFound, "O alimento não foi encontrado");

            await repository.DeletarAsync(alimento);
            await repository.SalvarMudancasAsync();
            return new Response<Alimento?>(null, EStatusCode.Ok, "Alimento deletado com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<Alimento?>(null, EStatusCode.BadRequest, $"Falha ao deletar alimento - {ex.Message}");
        }
        catch
        {
            return new Response<Alimento?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<PagedResponse<List<Alimento>?>> ListarAsync(ListarAlimentoRequest request)
    {
        try
        {
            var query = await repository.ListarTodosAsync();
            var count = await repository.Contagem();

            var alimentos = query.OrderBy(x => x.Nome)
                .Skip(request.PageNumber - 1 * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new PagedResponse<List<Alimento>?>(alimentos, request.PageSize, request.PageNumber, count);
        }
        catch 
        {
            return new PagedResponse<List<Alimento>?>(null, EStatusCode.BadRequest, "Não foi possivel listar os alimentos");
        }
    }

    public async Task<PagedResponse<List<Alimento>?>> ListarPorGrupoAlimentarAsync(ListarPorGrupoAlimentoRequest request)
    {
        try
        {
            var query = await repository.ListarTodosAsync
                (where: x => x.GrupoAlimentar == (EGrupoAlimentar)request.GrupoAlimentar);

            var count = await repository.Contagem(where: x => x.GrupoAlimentar == (EGrupoAlimentar)request.GrupoAlimentar);

            var alimentos = query.Skip(request.PageNumber - 1 * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new PagedResponse<List<Alimento>?>(alimentos, request.PageSize, request.PageNumber, count);
        }
        catch
        {
            return new PagedResponse<List<Alimento>?>(null, EStatusCode.BadRequest, "Não foi possivel listar os alimentos");
        }
    }
}