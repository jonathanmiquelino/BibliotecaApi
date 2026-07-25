using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Livros.Queries.ObterTodosLivros;

public class ObterTodosLivrosHandler : IRequestHandler<ObterTodosLivrosQuery, List<Livro>>
{
    private readonly ILivroRepository _livroRepository;

    public ObterTodosLivrosHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public Task<List<Livro>> Handle(ObterTodosLivrosQuery request, CancellationToken cancellationToken)
    {
        var livros = _livroRepository.GetAll();
        return Task.FromResult(livros);
    }
}