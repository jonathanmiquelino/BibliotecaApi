using BibliotecaApi.Domain.Entities;

namespace BibliotecaApi.Domain.Repositories
{
    public interface IEmprestimoRepository
    {
        List<Emprestimo> GetAll();
        List<Emprestimo> GetEmprestimosAtivosDoUsuario(int usuarioId);
        List<Emprestimo> GetEmprestimosDoUsuario(int usuarioId);
        Emprestimo GetById(int id);
        void Add(Emprestimo emprestimo);
        void Update(Emprestimo emprestimo);
        void Delete(int id);
    }
}