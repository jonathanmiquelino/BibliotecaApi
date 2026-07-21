using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using BibliotecaApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _appDbContext;

        public LivroRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Livro> GetAll()
        {
            return _appDbContext.Livros.ToList();
        }

        public Livro GetById(int id)
        {
            var livro = _appDbContext.Livros.FirstOrDefault(item => item.Id == id);
            return livro;
        }

        public void Add(Livro livro)
        {
            _appDbContext.Livros.Add(livro);
            _appDbContext.SaveChanges();
        }

        public void Update(Livro livro)
        {
            var buscaLivro = _appDbContext.Livros.FirstOrDefault(item => item.Id == livro.Id);
            if (buscaLivro == null)
            {
                throw new InvalidOperationException($"Livro com ID {livro.Id} não encontrado.");
            }
            buscaLivro.Titulo = livro.Titulo;
            buscaLivro.Autor = livro.Autor;
            buscaLivro.AnoPublicacao = livro.AnoPublicacao;
            buscaLivro.Editora = livro.Editora;
            buscaLivro.Tema = livro.Tema;
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var livro = _appDbContext.Livros.FirstOrDefault(item => item.Id == id);
            if (livro == null)
            {
                throw new InvalidOperationException($"Livro com ID {id} não encontrado.");
            }
            _appDbContext.Remove(livro);
            _appDbContext.SaveChanges();
        }
    }
}