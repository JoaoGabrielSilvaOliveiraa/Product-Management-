using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_2024.Models;

namespace MVC_2024.Controllers
{
    public class MovimentacaoController : Controller

    {

        private readonly ApplicationDbContext _context;

        public MovimentacaoController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movimentacoes = _context.Movimentacao
                                .Include(m => m.Estoque) //Aqui estou incluindo as informações do estoque
                                .ToList();
            return View(movimentacoes); //retorna as movimentações para a view 
        }

        public IActionResult Create()
        {
            ViewBag.Estoques = _context.Estoques.ToList();
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovimentacaoModel movimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Movimentacao.Add(movimentacao);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estoques = _context.Estoques.ToList();
            return View(movimentacao);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movimentacao = _context.Movimentacao
                                .Include(m => m.Estoque)
                                .FirstOrDefault(m => m.Id == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            ViewBag.Estoques = _context.Estoques.ToList();
            return View(movimentacao);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit (int id, MovimentacaoModel movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    _context.SaveChanges();
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Estoques = _context.Estoques.ToList();
            return View(movimentacao);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movimentacao = _context.Movimentacao
                                .Include(m => m.Estoque)
                                .FirstOrDefault(m => m.Id == id);

         
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movimentacao = _context.Movimentacao
                                      .FirstOrDefault(m => m.Id == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            _context.Movimentacao.Remove(movimentacao);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        }
    }
}


  
