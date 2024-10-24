using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;

public class RemoverRefeicaoNaFichaRequest : Request
{
    [Required(ErrorMessage = "O Id da ficha é necessário")]
    public int FichaId { get; set; }
    [Required(ErrorMessage = "O Id da refeição é necessário")]
    public int RefeicaoId { get; set; }
}