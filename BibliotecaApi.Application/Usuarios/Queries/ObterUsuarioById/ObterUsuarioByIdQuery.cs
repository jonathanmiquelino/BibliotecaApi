using BibliotecaApi.Domain.Entities;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Queries.ObterUsuarioById;

public class ObterUsuarioByIdQuery : IRequest<Usuario>
{
    public int Id { get; set; }
}