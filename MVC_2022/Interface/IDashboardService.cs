using MVC_2024.Models;
using System.Threading.Tasks;

namespace MVC_2024.Services
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboardDataAsync();
    }
}
