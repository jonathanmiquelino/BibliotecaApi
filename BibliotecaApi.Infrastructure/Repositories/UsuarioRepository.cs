using BibliotecaApi.Domain.Entities;
using BibliotecaApi.Domain.Repositories;
using BibliotecaApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Usuario> GetAll()
        {
            return _appDbContext.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(item => item.Id == id);
            return usuario;
        }

        public void Add(Usuario usuario)
        {
            _appDbContext.Usuarios.Add(usuario);
            _appDbContext.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            var buscaUsuario = _appDbContext.Usuarios.FirstOrDefault(item => item.Id == usuario.Id);
            if (buscaUsuario == null)
            {
                throw new InvalidOperationException($"Usuário com ID {usuario.Id} não encontrado.");
            }
            buscaUsuario.Email = usuario.Email;
            buscaUsuario.Telefone = usuario.Telefone;

            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _appDbContext.Usuarios.FirstOrDefault(item => item.Id == id);
            if (usuario == null)
            {
                throw new InvalidOperationException($"Usuário com ID {id} não encontrado.");
            }
            _appDbContext.Remove(usuario);
            _appDbContext.SaveChanges();
        }
    }
}