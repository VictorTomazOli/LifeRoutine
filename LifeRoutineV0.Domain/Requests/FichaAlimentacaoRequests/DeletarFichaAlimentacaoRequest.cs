using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;

public class DeletarFichaAlimentacaoRequest : Request
{
    [Required(ErrorMessage = "O Id da ficha é necessário")]
    public int Id{ get; set; }
}