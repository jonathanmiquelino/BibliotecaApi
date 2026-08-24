using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Queries.ObterUsuarioById;

public class ObterUsuarioByIdHandler : IRequestHandler<ObterUsuarioByIdQuery, Usuario>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioByIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<Usuario> Handle(ObterUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.GetById(request.Id);
        return Task.FromResult(usuario);
    }
}