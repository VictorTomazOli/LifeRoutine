using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Domain.Handlers;

public interface IFichaAlimentacaoHandler
{
    Task<Response<FichaAlimentacao?>> AdicionarRefeicaoNaFicha(AdicionarRefeicaoNaFichaRequest request);
    Task<Response<FichaAlimentacao?>> AtualizarRefeicaoNaFicha(AtualizarRefeicaoNaFichaRequest request);
    Task<Response<FichaAlimentacao?>> CriarAsync(CriarFichaAlimentacaoRequest request);
    Task<Response<FichaAlimentacao?>> DeletarAsync(DeletarFichaAlimentacaoRequest request);
    Task<PagedResponse<FichaAlimentacao?>> ListarAsync(ListarFichaAlimentacaoRequest request);
    Task<PagedResponse<List<Refeicao>?>> ListarRefeicaoPorTempo(ListarRefeicaoPorTempoRequest request);
    Task<Response<FichaAlimentacao?>> RemoverRefeicaoNaFicha(RemoverRefeicaoNaFichaRequest request);
}