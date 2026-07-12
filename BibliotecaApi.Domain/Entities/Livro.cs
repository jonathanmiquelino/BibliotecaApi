namespace BibliotecaApi.Domain.Entities
{
    public class Livro
    {
        public Livro
        (string titulo, string autor, int anoPublicacao, string editora, string tema, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Editora = editora;
            Tema = tema;
            Isbn = isbn;
            Disponivel = true;
        }

        public int Id { get; private set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Editora { get; set; }
        public string Tema { get; set; }
        public string Isbn { get; private set; }
        public bool Disponivel { get; private set; }

        public void Emprestar()
        {
            if (!Disponivel)
                throw new InvalidOperationException("O livro não está disponível para empréstimo.");
            Disponivel = false;
        }

        public void Devolver()
        {
            if (Disponivel)
                throw new InvalidOperationException("O livro não está emprestado.");
            Disponivel = true;
        }
    }


}