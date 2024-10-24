using System.ComponentModel.DataAnnotations;

namespace LifeRoutineV0.Domain.Requests.UsuarioRequests;

public class AtualizarSenhaUsuarioRequest : Request
{
    [Required(ErrorMessage = "A senha é obrigatório")]
    [StringLength(80, MinimumLength = 6, ErrorMessage = "Este campo deve ter entre 6 e 80 caracteres")]
    public string Senha { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatório")]
    [StringLength(80, MinimumLength = 6, ErrorMessage = "Este campo deve ter entre 6 e 80 caracteres")]
    public string SenhaConfirmacao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatório")]
    [StringLength(80, MinimumLength = 6, ErrorMessage = "Este campo deve ter entre 6 e 80 caracteres")]
    public string NovaSenha { get; set; } = string.Empty;
}