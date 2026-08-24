using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Commands.CriarUsuario;

public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioCommand, int>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(
            request.Nome,
            request.Cpf,
            request.Email,
            request.Telefone,
            request.DataNascimento
        );
        _usuarioRepository.Add(usuario);

        return usuario.Id;
    }
}