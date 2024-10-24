using SecureIdentity.Password;

namespace LifeRoutineV0.Domain.ValueObjects;

public class Senha
{
    protected Senha() { }

    public Senha(string senha)
    {
        SenhaHash = PasswordHasher.Hash(senha);
    }
    public string SenhaHash { get; private set; }

    public bool VerificacaoDeSenha(string senhaTestar)
    {
        if (PasswordHasher.Verify(SenhaHash, senhaTestar))
            return true;

        return false;
    }

    public bool AlterarSenha(string senhaAntiga, string novaSenha, string novaSenhaConfirmacao)
    {
        if (VerificacaoDeSenha(senhaAntiga) && novaSenha.Equals(novaSenhaConfirmacao))
        {
            SenhaHash = PasswordHasher.Hash(novaSenha);
            return true;
        }

        return false;
    }
}