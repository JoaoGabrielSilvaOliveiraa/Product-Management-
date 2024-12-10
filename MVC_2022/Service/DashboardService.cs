using MVC_2024.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_2024.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _dbContext;

        public DashboardService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dashboard> GetDashboardDataAsync()
        {
            var dashboard = new Dashboard
            {
                // Total de estoques
                TotalEstoques = await _dbContext.Estoques.CountAsync(),

                // Total de movimentações
                TotalMovimentacoes = await _dbContext.Movimentacao.CountAsync()
            };

            return dashboard;
        }
    }
}
