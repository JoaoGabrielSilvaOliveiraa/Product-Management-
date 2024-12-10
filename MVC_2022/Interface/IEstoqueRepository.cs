using MVC_2024.Models;

public interface IEstoqueRepository
{
    Task<IEnumerable<EstoqueModel>> GetAllEstoqueAsync();
    Task<EstoqueModel> GetEstoqueByIdAsync(int id);
    Task AddEstoqueAsync(EstoqueModel estoque);
    Task UpdateEstoqueAsync(EstoqueModel estoque);
    Task DeleteEstoqueAsync(int id);
}