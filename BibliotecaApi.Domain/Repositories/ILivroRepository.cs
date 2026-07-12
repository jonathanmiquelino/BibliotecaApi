using BibliotecaApi.Domain.Entities;

namespace BibliotecaApi.Domain.Repositories
{
    public interface ILivroRepository
    {
        List<Livro> GetAll();
        Livro GetById(int id);
        void Add(Livro livro);
        void Update(Livro livro);
        void Delete(int id);
    }
}