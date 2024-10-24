using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;

public class AtualizarRefeicaoNaFichaRequest : Request
{
    [Required(ErrorMessage = "O Id da ficha é necessário")]
    public int FichaId { get; set; }
    public DateTime? DataCriacao { get; set; }
}