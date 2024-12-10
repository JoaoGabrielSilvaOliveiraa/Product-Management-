using Microsoft.AspNetCore.Mvc;
using MVC_2024.Models;
using MVC_2024.Services; // Adicionando o namespace do Service
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_2024.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly EstoqueService _estoqueService; // Usando o serviço

        // Injeção de dependência para o Service
        public EstoqueController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        // Index que agora usa o serviço para buscar os estoques
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueService.GetAllEstoqueAsync(); // Usando o serviço
            return View(estoques); // Passando os dados para a View
        }

        // Método para exibir o formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        // Método para criar o estoque, agora usando o serviço
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstoqueModel estoque)
        {
            if (!ModelState.IsValid)
            {
                // Adicione um log ou ponto de interrupção para ver o que está causando o erro
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Ou algum log para depuração
                }
                return View(estoque);
            }

            await _estoqueService.AddEstoqueAsync(estoque);
            return RedirectToAction(nameof(Index));
        }



        // Método para editar o estoque
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var estoque = await _estoqueService.GetEstoqueByIdAsync(id); // Usando o serviço
            if (estoque == null)
            {
                return NotFound();
            }
            return View(estoque);
        }

        // Método POST para salvar alterações no estoque
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstoqueModel estoque)
        {
            if (id != estoque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _estoqueService.UpdateEstoqueAsync(estoque); // Usando o serviço
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estoque);
        }

        // Método GET para excluir o estoque
        // Método GET para excluir o estoque - Agora exclui diretamente o item
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var estoque = await _estoqueService.GetEstoqueByIdAsync(id); // Usando o serviço
            if (estoque == null)
            {
                return NotFound();
            }

            // Exclui o estoque diretamente
            await _estoqueService.DeleteEstoqueAsync(id); // Usando o serviço

            // Redireciona para a lista de estoques após a exclusão
            return RedirectToAction(nameof(Index));
        }


    }
}
