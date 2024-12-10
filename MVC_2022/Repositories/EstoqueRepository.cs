using MVC_2024.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_2024.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ApplicationDbContext _context;

        public EstoqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação do método assíncrono GetAllEstoque
        public async Task<IEnumerable<EstoqueModel>> GetAllEstoqueAsync()
        {
            return await _context.Estoques.ToListAsync();
        }

        // Implementação do método assíncrono GetEstoqueById
        public async Task<EstoqueModel> GetEstoqueByIdAsync(int id)
        {
            return await _context.Estoques.FirstOrDefaultAsync(e => e.Id == id);
        }

        // Implementação do método assíncrono AddEstoque
        public async Task AddEstoqueAsync(EstoqueModel estoque)
        {
            await _context.Estoques.AddAsync(estoque);
            await _context.SaveChangesAsync(); // Aqui você confirma que a adição está sendo salva
        }


        // Implementação do método assíncrono UpdateEstoque
        public async Task UpdateEstoqueAsync(EstoqueModel estoque)
        {
            _context.Update(estoque);
            await _context.SaveChangesAsync();
        }

        // Implementação do método assíncrono DeleteEstoque
        public async Task DeleteEstoqueAsync(int id)
        {
            var estoque = await _context.Estoques.FirstOrDefaultAsync(e => e.Id == id);
            if (estoque != null)
            {
                _context.Estoques.Remove(estoque);
                await _context.SaveChangesAsync();
            }
        }
    }
}
