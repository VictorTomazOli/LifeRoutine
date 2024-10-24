using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Requests.ContaRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Domain.Handlers;

public interface IContaHandler
{
    Task<Response<Usuario?>> CriarAsync(CriarContaRequest request);
    Task<Response<Usuario?>> LoginAsync(LoginContaRequest request);
}