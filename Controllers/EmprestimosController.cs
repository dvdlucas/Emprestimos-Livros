using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
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

        
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModelcs emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);

        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModelcs emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Update(emprestimo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(emprestimo);

        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModelcs emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }



        [HttpPost]
        public IActionResult Excluir(EmprestimosModelcs emprestimo)
        {
           if(emprestimo == null)
            {
                return NotFound();
            }
                _context.Emprestimos.Remove(emprestimo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }
  
    }
}
