using lemeC.API.Context;
using lemeC.API.Models;
using lemeC.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lemeC.API.Repositories
{
    public class PedidoRepository : PedidoIntRepository
    {
        private readonly LemeDbContext _dbContext;
        private Pedido pedidos;
        public async Task<Pedido> Adicionar(Pedido Itens)
        {
            await _dbContext.Itens.AddAsync(pedidos);
            await _dbContext.SaveChangesAsync();
            return pedidos;
        }

        public async Task<bool> Apagar(int id)
        {
            Pedido pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"ID {id} não encontrado!");
            }
            _dbContext.Itens.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();
            return true; throw new NotImplementedException();
        }

        public async Task<Pedido> Atualizar(Pedido Itens, int id)
        {
            Pedido pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"ID {id} não encontrado!");
            }

            _dbContext.Entry(pedidoPorId).State = EntityState.Modified;
            return pedidoPorId; throw new NotImplementedException();
        }

        public async Task<Pedido> BuscarPorId(int id)
        {
            return await _dbContext.Itens.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pedido>> BuscarTodos()
        {
            return await _dbContext.Itens.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
