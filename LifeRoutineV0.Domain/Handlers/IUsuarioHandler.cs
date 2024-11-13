using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Requests.ContaRequests;
using LifeRoutineV0.Domain.Requests.UsuarioRequests;
using LifeRoutineV0.Domain.Responses;

namespace LifeRoutineV0.Domain.Handlers;

public interface IUsuarioHandler
{
    Task<Response<Usuario?>> AtualizarSenhaAsync(AtualizarSenhaUsuarioRequest request);
    Task<Response<Usuario?>> AtualizarAsync(AtualizarUsuarioRequest request);
    Task<Response<Usuario?>> CriarAsync(CriarContaRequest request);
    Task<Response<Usuario?>> DeletarAsync(DeletarUsuarioRequest request);
    Task<Response<Usuario?>> ListarAsync(ListarUsuarioRequest request);
    Task<Response<string?>> LoginAsync(LoginContaRequest request);

}