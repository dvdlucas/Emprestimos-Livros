using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimos_Livros.Controllers
{
    public class EmprestimosController : Controller
    {
        readonly private ApplicationDbContext _context;
        public EmprestimosController(ApplicationDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModelcs> emprestimos = _context.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModelcs emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Add(emprestimo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
