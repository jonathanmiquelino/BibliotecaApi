using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Livros.Commands.CriarLivro
{
    public class CriarLivroHandler : IRequestHandler<CriarLivroCommand, int>
    {
        private readonly ILivroRepository _livroRepository;

        public CriarLivroHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<int> Handle(CriarLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro(
                request.Titulo,
                request.Autor,
                request.AnoPublicacao,
                request.Editora,
                request.Tema,
                request.Isbn
            );
            _livroRepository.Add(livro);
            
            return livro.Id;
        }
    }
}