using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.AlimentoRequests;

public class AtualizarAlimentoRequest : Request
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Este campo deve ter entre 3 e 80 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O grupo alimentar é obrigatório")]
    public int GrupoAlimentar { get; set; }
}