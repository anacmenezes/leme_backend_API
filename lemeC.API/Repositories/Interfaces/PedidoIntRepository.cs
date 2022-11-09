using lemeC.API.Models;

namespace lemeC.API.Repositories.Interfaces
{
    public interface PedidoIntRepository
    {
        Task<IEnumerable<Pedido>> BuscarTodos();
        Task<Pedido> BuscarPorId(int id);
        Task<Pedido> Adicionar(Pedido Itens);
        Task<Pedido> Atualizar(Pedido Itens, int id);
        Task<bool> Apagar(int id);
        Task<bool> SaveAll();
    }
}
