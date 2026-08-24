using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Queries.ObterTodosUsuarios;

public class ObterTodosUsuariosHandler : IRequestHandler<ObterTodosUsuariosQuery, List<Usuario>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    public ObterTodosUsuariosHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<List<Usuario>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
    {
        var usuarios = _usuarioRepository.GetAll();
        return Task.FromResult(usuarios);
    }
}