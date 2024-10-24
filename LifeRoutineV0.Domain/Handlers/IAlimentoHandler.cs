using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Requests.AlimentoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Domain.Handlers;

public interface IAlimentoHandler
{
    Task<Response<Alimento?>> AtualizarAsync(AtualizarAlimentoRequest request);
    Task<Response<Alimento?>> CriarAsync(CriarAlimentoRequest request);
    Task<Response<Alimento?>> DeletarAsync(DeletarAlimentoRequest request);
    Task<PagedResponse<List<Alimento>?>> ListarAsync(ListarAlimentoRequest request);
    Task<PagedResponse<List<Alimento>?>> ListarPorGrupoAlimentarAsync(ListarPorGrupoAlimentoRequest request);
}