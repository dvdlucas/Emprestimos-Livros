using Emprestimos_Livros.Models;
using Emprestimos_Livros.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimos_Livros.Controllers
{
    public class LivrosController : Controller
    {
        private readonly UsuariosServices _usuarioService;
        private readonly LivrosService _livrosService;

        public LivrosController(UsuariosServices usuariosServices, LivrosService livrosService)
        {
            _usuarioService = usuariosServices;
            _livrosService = livrosService;
        }
        public IActionResult Index()
        {
            IEnumerable<LivroModel> livros = _livrosService.GetAllLivrosService();
            return View(livros);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var usuarios = _usuarioService.GetAllUsuarioService().ToList();
            ViewBag.Usuarios = usuarios;

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(LivroModel livro)
        {
            _livrosService.CadastrarLivroService(livro);
            TempData["MensagemSucesso"] = "Livro cadastrado com Sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
           LivroModel livro = _livrosService.GetLivroServiceById(id);
            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(LivroModel livro)
        {
            try
            {
                _livrosService.EditarLivroService(livro);
                TempData["MensagemSucesso"] = "Edição Realizada com sucesso!";
                RedirectToAction("Index");
            } catch (Exception ex)
            {
                TempData["MensagemErro"] = "Deu merda " + ex;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            LivroModel livro = _livrosService.GetLivroServiceById(id);
            return View(livro);
        }

        [HttpPost]
        public IActionResult Excluir(LivroModel livro)
        {
            try
            {
                _livrosService.ExcluirLivroService(livro);
                TempData["MensagemSucesso"] = "Exclusão Realizada com Sucesso";
                RedirectToAction("Index");
            } catch (Exception ex)
            {
                TempData["MensagemErro"] = "Deu merda " + ex;
            }
            return View();
        }

    }
}
