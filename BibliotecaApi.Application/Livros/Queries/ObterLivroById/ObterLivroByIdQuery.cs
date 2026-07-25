using BibliotecaApi.Domain.Entities;
using MediatR;

namespace BibliotecaApi.Application.Livros.Queries.ObterLivroById;

public class ObterLivroByIdQuery : IRequest<Livro>
{
    public int Id { get; set; }
}