using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Livros.Commands.DeletarLivroById;

public class DeletarLivroByIdHandler : IRequestHandler<DeletarLivroByIdCommand>
{
    private readonly ILivroRepository _livroRepository;

    public DeletarLivroByIdHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task Handle(DeletarLivroByIdCommand request, CancellationToken cancellationToken)
    {
        var livro = _livroRepository.GetById(request.Id);
        if(livro == null)
            throw new InvalidOperationException($"Livro com ID {request.Id} não encontrado.");
        
        _livroRepository.Delete(request.Id);
    }
}