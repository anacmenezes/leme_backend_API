using lemeC.API.Context;
using lemeC.API.Models;
using lemeC.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lemeC.API.Repositories
{
    public class ClienteRepository : ClienteIntRepository
    {
        private readonly LemeDbContext _dbContext;
        private Cliente usuarios;

        public ClienteRepository(LemeDbContext Context)
        {
            _dbContext = Context;
        }

        public async Task<Cliente> Adicionar(Cliente user)
        {
            await _dbContext.User.AddAsync(usuarios);
            await _dbContext.SaveChangesAsync();
            return usuarios;
        }

        public async Task<bool> Apagar(int id)
        {
            Cliente clientePorId = await BuscarPorId(id);
            if (clientePorId == null)
            {
                throw new Exception($"ID {id} não encontrado!");
            }
            _dbContext.User.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true; throw new NotImplementedException();
        }

        public async Task<Cliente> Atualizar(Cliente user, int id)
        {
            Cliente clientePorId = await BuscarPorId(id);
            if (clientePorId == null)
            {
                throw new Exception($"ID {id} não encontrado!");
            }
            
            _dbContext.Entry(clientePorId).State = EntityState.Modified;
            return clientePorId; throw new NotImplementedException();
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            return await _dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> BuscarTodos()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
