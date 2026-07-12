using BibliotecaApi.Domain.Entities;

namespace BibliotecaApi.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}