using BibliotecaApi.Domain.Entities;
using MediatR;

namespace BibliotecaApi.Application.Livros.Queries.ObterTodosLivros;

public class ObterTodosLivrosQuery : IRequest<List<Livro>>
{
    
}