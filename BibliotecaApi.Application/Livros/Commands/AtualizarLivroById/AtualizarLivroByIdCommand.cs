using BibliotecaApi.Domain.Entities;
using MediatR;

namespace BibliotecaApi.Application.Livros.Commands.AtualizarLivroById;

public class AtualizarLivroByIdCommand : IRequest<Livro>
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public string Editora { get; set; }
    public string Tema { get; set; }
}