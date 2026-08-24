using MediatR;

namespace BibliotecaApi.Application.Usuarios.Commands.DeletarUsuarioById;

public class DeletarUsuarioByIdCommand : IRequest
{
    public int Id { get; set; }
}