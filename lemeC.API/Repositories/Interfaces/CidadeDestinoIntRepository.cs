using lemeC.API.Models;

namespace lemeC.API.Repositories.Interfaces
{
    public interface CidadeDestinoIntRepository
    {
        Task<IEnumerable<CidadeDestino>> BuscarTodos();
        Task<CidadeDestino> BuscarPorId(int id);
        Task<CidadeDestino> Adicionar(CidadeDestino Dest);
        Task<CidadeDestino> Atualizar(CidadeDestino Dest, int id);
        Task<bool> Apagar(int id);
        Task<bool> SaveAll();
    }
}
