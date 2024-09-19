namespace LifeRoutine.Domain.ValueObjects;

public class Senha
{
    public Senha(string senha)
    {
        CriptografarSenha(senha);
        SenhaHash = senha;
        
    }
    public string SenhaHash { get; private set; }

    public void CriptografarSenha(string senha)
    {
        //Hash na senha antes de ir para o banco
    }

    public bool VerificacaoDeSenha(string senhaTestar)
    {
        // Verifica se a senha esta valida no login
    }
}