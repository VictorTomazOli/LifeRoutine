using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.ContaRequests;

public class LoginContaRequest
{
    [Required(ErrorMessage = "O Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O Email é inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatório")]
    [StringLength(80, MinimumLength = 6, ErrorMessage = "Este campo deve ter entre 6 e 80 caracteres")]
    public string Senha { get; set; } = string.Empty;
}