using MediatR;

namespace BibliotecaApi.Application.Usuarios.Commands.CriarUsuario;

public class CriarUsuarioCommand : IRequest<int>
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateOnly DataNascimento { get; set; }
}