using BibliotecaApi.Domain.Entities;
using MediatR;

namespace BibliotecaApi.Application.Usuarios.Commands.AtualizarusuarioByID;

public class AtualizarUsuarioByIdCommand : IRequest<Usuario>
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}