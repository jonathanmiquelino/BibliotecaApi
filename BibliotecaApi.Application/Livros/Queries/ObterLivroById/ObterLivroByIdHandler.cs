using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Livros.Queries.ObterLivroById;

public class ObterLivroByIdHandler : IRequestHandler<ObterLivroByIdQuery, Livro>
{
    private readonly ILivroRepository _livroRepository;

    public ObterLivroByIdHandler(ILivroRepository livroRepository)
    {
       _livroRepository = livroRepository;
    }
    
    public Task<Livro> Handle(ObterLivroByIdQuery request, CancellationToken cancellationToken)
    {
        var livro = _livroRepository.GetById(request.Id);
        return Task.FromResult(livro);
    }
}