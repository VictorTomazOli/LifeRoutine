using System.Text.RegularExpressions;

namespace LifeRoutineV0.Domain.ValueObjects;

public class Email
{
    protected Email() { }

    public Email(string email)
    {
        EnderecoDeEmail = email;
    }

    public string EnderecoDeEmail { get; private set; }

    public bool ValidarEmail()
    {
        string regex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$";
        if (Regex.IsMatch(EnderecoDeEmail, regex))
        {
            return true;
        }

        return false;
    }
}