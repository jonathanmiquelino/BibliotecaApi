using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Enums;
using BibliotecaApi.Domain.Repositories;
using BibliotecaApi.Infrastructure.Data;

namespace BibliotecaApi.Infrastructure.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmprestimoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Emprestimo> GetAll()
        {
            return _appDbContext.Emprestimos.ToList();
        }

        public Emprestimo GetById(int id)
        {
            var emprestimo = _appDbContext.Emprestimos.FirstOrDefault(item => item.Id == id);
            return emprestimo;
        }

        public void Add(Emprestimo emprestimo)
        {
            _appDbContext.Emprestimos.Add(emprestimo);
            _appDbContext.SaveChanges();
        }

        public void Update(Emprestimo emprestimo)
        {
            _appDbContext.Emprestimos.Update(emprestimo);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var emprestimo = _appDbContext.Emprestimos.FirstOrDefault(item => item.Id == id);
            if (emprestimo == null)
            {
                throw new InvalidOperationException($"Emprestimo com ID {id} não encontrado.");
            }
            _appDbContext.Remove(emprestimo);
            _appDbContext.SaveChanges();
        }

        public List<Emprestimo> GetEmprestimosDoUsuario(int usuarioId)
        {
            return _appDbContext.Emprestimos
            .Where(e => e.UsuarioId == usuarioId)
            .ToList();
        }

        public List<Emprestimo> GetEmprestimosAtivosDoUsuario(int usuarioId)
        {
            return _appDbContext.Emprestimos
            .Where(e => e.UsuarioId == usuarioId && e.Status == StatusEmprestimo.Ativo)
            .ToList();
        }
    }
}