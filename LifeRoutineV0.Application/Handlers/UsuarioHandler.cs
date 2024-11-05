﻿using LifeRoutineV0.Domain.Entities;
using LifeRoutineV0.Domain.Enums;
using LifeRoutineV0.Domain.Handlers;
using LifeRoutineV0.Domain.Repositories;
using LifeRoutineV0.Domain.Requests.UsuarioRequests;
using LifeRoutineV0.Domain.Responses;
using LifeRoutineV0.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace LifeRoutineV0.Application.Handlers;

public class UsuarioHandler(IUsuarioRepository repository) : IUsuarioHandler
{
    public async Task<Response<Usuario?>> AtualizarAsync(AtualizarUsuarioRequest request)
    {
        try
        {
            var usuario = await repository.ListarPorIdAsync(request.UserId);
            if (usuario is null)
                return new Response<Usuario?>(null, EStatusCode.NotFound, "Usuário não foi encontrado");

            var email = new Email(request.Email);

            if (!email.ValidarEmail())
                return new Response<Usuario?>(null, EStatusCode.BadRequest, "O Email é inválido");

            usuario.AlterarUsuario(request.Nome, email, request.DataCriacao);

            await repository.AtualizarAsync(usuario);
            await repository.SalvarMudancasAsync();
            return new Response<Usuario?>(usuario, EStatusCode.Ok, "Usuário foi atualizado com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<Usuario?>(null, EStatusCode.BadRequest, $"Falha ao atualizar usuario - {ex.Message}");
        }
        catch
        {
            return new Response<Usuario?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<Usuario?>> AtualizarSenhaAsync(AtualizarSenhaUsuarioRequest request)
    {
        try
        {
            var usuario = await repository.ListarPorIdAsync(request.UserId);
            if (usuario is null)
                return new Response<Usuario?>(null, EStatusCode.NotFound, "Usuário não foi encontrado");

            if (!usuario.Senha.AlterarSenha(request.Senha, request.NovaSenha, request.SenhaConfirmacao))
                return new Response<Usuario?>(null, EStatusCode.BadRequest,
                    "Senha inválida ou as senhas são diferentes");

            await repository.AtualizarAsync(usuario);
            await repository.SalvarMudancasAsync();
            return new Response<Usuario?>(usuario, EStatusCode.Ok, "A senha foi atualizada com sucesso");
        }
        catch (DbUpdateException)
        {
            return new Response<Usuario?>(null, EStatusCode.BadRequest, $"Falha ao atualizar senha do usuário");
        }
        catch
        {
            return new Response<Usuario?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<Usuario?>> DeletarAsync(DeletarUsuarioRequest request)
    {
        try
        {
            var usuario = await repository.ListarPorIdAsync(request.UserId);
            if (usuario is null)
                return new Response<Usuario?>(null, EStatusCode.NotFound, "Usuário não foi encontrado");

            await repository.DeletarAsync(usuario);
            await repository.SalvarMudancasAsync();
            return new Response<Usuario?>(null, EStatusCode.Ok, "Usuário deletado com sucesso");
        }
        catch (DbUpdateException ex)
        {
            return new Response<Usuario?>(null, EStatusCode.BadRequest, $"Falha ao deletar usuário - {ex.Message}");
        }
        catch
        {
            return new Response<Usuario?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }

    public async Task<Response<Usuario?>> ListarAsync(ListarUsuarioRequest request)
    {
        try
        {
            var usuario = await repository.ListarPorIdAsNoTracking(request.UserId, ["FichaAlimentacao"]);
            if (usuario is null)
                return new Response<Usuario?>(null, EStatusCode.NotFound, "Usuário não foi encontrado");

            return new Response<Usuario?>(usuario, EStatusCode.Ok);
        }
        catch
        {
            return new Response<Usuario?>(null, EStatusCode.InternalServerError, "Falha interna no servidor");
        }
    }
}