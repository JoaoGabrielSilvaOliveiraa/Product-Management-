using MVC_2024.Models;
using MVC_2024.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_2024.Services
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;

        // Injeção de dependência para o repositório
        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        // Método para obter todos os estoques
        public async Task<IEnumerable<EstoqueModel>> GetAllEstoqueAsync()
        {
            return await _estoqueRepository.GetAllEstoqueAsync();
        }

        // Método para obter estoque por ID
        public async Task<EstoqueModel> GetEstoqueByIdAsync(int id)
        {
            return await _estoqueRepository.GetEstoqueByIdAsync(id);
        }

        // Método para adicionar um novo estoque
        public async Task AddEstoqueAsync(EstoqueModel estoque)
        {
            await _estoqueRepository.AddEstoqueAsync(estoque);
        }

        // Método para atualizar um estoque existente
        public async Task UpdateEstoqueAsync(EstoqueModel estoque)
        {
            await _estoqueRepository.UpdateEstoqueAsync(estoque);
        }

        // Método para excluir um estoque pelo ID
        public async Task DeleteEstoqueAsync(int id)
        {
            await _estoqueRepository.DeleteEstoqueAsync(id);
        }
    }
}
