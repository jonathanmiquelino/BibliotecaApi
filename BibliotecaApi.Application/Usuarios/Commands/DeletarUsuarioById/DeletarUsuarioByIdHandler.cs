using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Commands.DeletarUsuarioById;

public class DeletarUsuarioByIdHandler : IRequestHandler<DeletarUsuarioByIdCommand>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeletarUsuarioByIdHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task Handle(DeletarUsuarioByIdCommand request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.GetById(request.Id);
        if(usuario == null)
            throw new InvalidOperationException($"usuario com ID {request.Id} não encontrado.");
        
        _usuarioRepository.Delete(request.Id);
    }
    

}