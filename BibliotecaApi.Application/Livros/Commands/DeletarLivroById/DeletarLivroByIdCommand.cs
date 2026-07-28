using BibliotecaApi.Domain.Entities;
using MediatR;

namespace BibliotecaApi.Application.Livros.Commands.DeletarLivroById;

public class DeletarLivroByIdCommand : IRequest
{
    public int Id { get; set; }
}