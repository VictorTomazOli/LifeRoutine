namespace LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;

public class ListarRefeicaoPorTempoRequest : PagedRequest
{
    public DateTime? TempoInicial { get; set; }
    public DateTime? TempoFinal { get; set; }
}