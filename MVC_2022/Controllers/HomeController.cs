using Microsoft.AspNetCore.Mvc;
using MVC_2024.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVC_2024.Services;

namespace MVC_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly EstoqueService _estoqueService;

        public HomeController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueService.GetAllEstoqueAsync(); // Obtendo a lista de estoques
            return View(estoques); // Passando a lista para a view
        }
    }
}
