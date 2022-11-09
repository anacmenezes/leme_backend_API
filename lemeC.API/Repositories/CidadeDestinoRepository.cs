using lemeC.API.Context;
using lemeC.API.Models;
using lemeC.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lemeC.API.Repositories
{
    public class CidadeDestinoRepository : CidadeDestinoIntRepository
    {
        private readonly LemeDbContext _dbContext;
        private CidadeDestino destinos;

        public async Task<CidadeDestino> Adicionar(CidadeDestino dest)
        {
            await _dbContext.Dest.AddAsync(destinos);
            await _dbContext.SaveChangesAsync();
            return destinos;
        }

        public async Task<bool> Apagar(int id)
        {
            CidadeDestino destinoPorId = await BuscarPorId(id);
            if (destinoPorId == null)
            {
                throw new Exception($"ID {id} não encontrado!");
            }
            _dbContext.Dest.Remove(destinoPorId);
            await _dbContext.SaveChangesAsync();
            return true; throw new NotImplementedException();
        }

        public async Task<CidadeDestino> Atualizar(CidadeDestino dest, int id)
        {
            CidadeDestino destinoPorId = await BuscarPorId(id);
            if (destinoPorId == null)
            {
                throw new Exception($"ID {id} não encontrado!");
            }

            _dbContext.Entry(destinoPorId).State = EntityState.Modified;
            return destinoPorId; throw new NotImplementedException();
        }

        public async Task<CidadeDestino> BuscarPorId(int id)
        {
            return await _dbContext.Dest.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CidadeDestino>> BuscarTodos()
        {
            return await _dbContext.Dest.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
