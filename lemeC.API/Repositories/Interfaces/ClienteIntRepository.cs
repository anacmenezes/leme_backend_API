using lemeC.API.Models;

namespace lemeC.API.Repositories.Interfaces
{
    public interface ClienteIntRepository
    {
        Task<IEnumerable<Cliente>> BuscarTodos();
        Task<Cliente> BuscarPorId(int id);
        Task<Cliente> Adicionar(Cliente user);
        Task<Cliente> Atualizar(Cliente user, int id);
        Task<bool> Apagar(int id);
        Task<bool> SaveAll();
    }
}
