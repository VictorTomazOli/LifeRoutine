using System.Text.RegularExpressions;

namespace LifeRoutine.Domain.ValueObjects;

public class Email
{
    protected Email() { }
    public string EnderecoDeEmail { get; private set; } = string.Empty;

    public bool ValidarEmail()
    {
        string regex ="/^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+\\.([a-z]+)?$/i/^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+\\.([a-z]+)?$/i";
        if(Regex.IsMatch(EnderecoDeEmail, regex))
        {
            return true;
        }

        return false;
    }
}
