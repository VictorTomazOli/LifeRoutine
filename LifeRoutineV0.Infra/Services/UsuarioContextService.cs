using LifeRoutineV0.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LifeRoutineV0.Infra.Services;

public class UsuarioContextService (IHttpContextAccessor httpContextAcessor) : IUsuarioContextService
{
    public int GetUserId()
    {
        var userIdS = httpContextAcessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(userIdS, out int userId) ? userId : 0;
    }
}
