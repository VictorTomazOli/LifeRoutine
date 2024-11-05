using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Domain.Handlers;

public interface IFichaAlimentacaoHandler
{
    Task<Response<Refeicao?>> AdicionarRefeicaoNaFichaAsync(AdicionarRefeicaoNaFichaRequest request);
    Task<Response<FichaAlimentacao?>> AtualizarRefeicaoNaFichaAsync(AtualizarRefeicaoNaFichaRequest request);
    Task<Response<FichaAlimentacao?>> CriarAsync(CriarFichaAlimentacaoRequest request);
    Task<Response<FichaAlimentacao?>> DeletarAsync(DeletarFichaAlimentacaoRequest request);
    Task<PagedResponse<FichaAlimentacao?>> ListarAsync(ListarFichaAlimentacaoRequest request);
    Task<Response<Refeicao?>> ListarRefeicaoAsync(ListarRefeicaoNaFichaRequest request);
    Task<PagedResponse<List<Refeicao>?>> ListarRefeicaoPorTempoAsync(ListarRefeicaoPorTempoRequest request);
    Task<Response<FichaAlimentacao?>> RemoverRefeicaoNaFichaAsync(RemoverRefeicaoNaFichaRequest request);
}