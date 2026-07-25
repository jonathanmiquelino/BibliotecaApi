using MediatR;

namespace BibliotecaApi.Application.Livros.Commands.CriarLivro
{
    public class CriarLivroCommand : IRequest<int>
    {
         public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Editora { get; set; }
        public string Tema { get; set; }
        public string Isbn { get; set; }
    }
}