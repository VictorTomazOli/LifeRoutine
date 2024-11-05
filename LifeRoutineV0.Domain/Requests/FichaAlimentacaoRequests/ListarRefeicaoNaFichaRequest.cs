namespace LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;

public class ListarRefeicaoNaFichaRequest : Request
{
    public int FichaId { get; set; }
    public int RefeicaoId { get; set; }
}