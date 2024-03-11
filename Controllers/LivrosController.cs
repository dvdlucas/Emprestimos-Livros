using Microsoft.AspNetCore.Mvc;

namespace Emprestimos_Livros.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
