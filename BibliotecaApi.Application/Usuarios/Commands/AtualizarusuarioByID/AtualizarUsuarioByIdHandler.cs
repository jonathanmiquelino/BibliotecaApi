using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Commands.AtualizarusuarioByID;

public class AtualizarUsuarioByIdHandler : IRequestHandler<AtualizarUsuarioByIdCommand, Usuario>
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    public AtualizarUsuarioByIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> Handle(AtualizarUsuarioByIdCommand request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.GetById(request.Id);
        if(usuario == null)
            throw new InvalidOperationException($"Usuario com ID {request.Id} não encontrado.");

        usuario.Email = request.Email;
        usuario.Telefone = request.Telefone;

        _usuarioRepository.Update(usuario);

        return await Task.FromResult(usuario);
    }
}