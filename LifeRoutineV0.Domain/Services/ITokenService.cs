using LifeRoutineV0.Domain.Entities;

namespace LifeRoutineV0.Domain.Services;

public interface ITokenService 
{
    string GerarToken(Usuario usuario);
}


