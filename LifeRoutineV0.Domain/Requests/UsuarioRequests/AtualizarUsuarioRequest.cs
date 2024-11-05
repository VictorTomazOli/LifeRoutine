using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.UsuarioRequests;

public class AtualizarUsuarioRequest : Request
{
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Este campo deve ter entre 3 e 40 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "O Email é inválido")]
    public string Email { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
}