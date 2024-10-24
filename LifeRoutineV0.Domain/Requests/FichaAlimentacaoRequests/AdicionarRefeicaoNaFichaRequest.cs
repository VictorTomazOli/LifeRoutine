using LifeRoutineV0.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.FichaAlimentacaoRequests;

public class AdicionarRefeicaoNaFichaRequest : Request
{
    [Required(ErrorMessage ="O Id da ficha é necessário")]
    public int FichaId { get; set; }
    public DateTime? DataCriacao { get; set; }
    public List<Alimento> Alimentos { get; set; } = new();
}