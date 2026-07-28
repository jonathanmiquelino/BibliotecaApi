using BibliotecaApi.Application.Livros.Queries.ObterLivroById;
using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using MediatR;

namespace BibliotecaApi.Application.Livros.Commands.AtualizarLivroById;

public class AtualizarLivroByIdHandler : IRequestHandler<AtualizarLivroByIdCommand, Livro>
{
   private readonly ILivroRepository _livroRepository;

   public AtualizarLivroByIdHandler(ILivroRepository livroRepository)
   {
      _livroRepository = livroRepository;
   }

   public async Task<Livro> Handle(AtualizarLivroByIdCommand request, CancellationToken cancellationToken)
   {
      var livro = _livroRepository.GetById(request.Id);
      if(livro == null)
         throw new InvalidOperationException($"Livro com ID {request.Id} não encontrado.");

      livro.Titulo = request.Titulo;
      livro.Autor = request.Autor;
      livro.AnoPublicacao = request.AnoPublicacao;
      livro.Editora = request.Editora;
      livro.Tema = request.Tema;

      _livroRepository.Update(livro);

      return await Task.FromResult(livro);
   }
}