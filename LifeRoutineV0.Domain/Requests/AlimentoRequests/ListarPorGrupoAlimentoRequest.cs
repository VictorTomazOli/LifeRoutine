namespace LifeRoutineV0.Domain.Requests.AlimentoRequests;

public class ListarPorGrupoAlimentoRequest : PagedRequest
{
    public int GrupoAlimentar { get; set; }
}