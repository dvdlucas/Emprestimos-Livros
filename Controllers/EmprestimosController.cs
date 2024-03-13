using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Emprestimos_Livros.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Emprestimos_Livros.Controllers
{
    public class EmprestimosController : Controller
    {
        readonly private EmprestimosService _serviceEmprestimo;
        private readonly UsuariosServices _usuariosService;
        private readonly LivrosService _livrosService;
   
        public EmprestimosController(EmprestimosService serviceEmprestimo, UsuariosServices usuariosServices, LivrosService livrosService)
        {
            _serviceEmprestimo = serviceEmprestimo;
            _usuariosService = usuariosServices;
            _livrosService = livrosService;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModelcs> emprestimos = _serviceEmprestimo.GetAllEmprestimos();
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var usuarios = _usuariosService.GetAllUsuarioService().ToList();
            var livros = _livrosService.GetAllLivrosService().ToList();
            ViewBag.Usuarios = usuarios;
            ViewBag.Livros = livros;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModelcs emprestimo)
        {
            var resultado = _serviceEmprestimo.AdicionarEmprestimo(emprestimo, resultado);
            if(resultado.Sucesso)
            {
                _serviceEmprestimo.AdicionarEmprestimo(emprestimo, resultado);
                TempData["MensagemSucesso"] = "Cadastro Realizado com Sucesso";
                return RedirectToAction("Index");
            } 
            else
            {
                TempData["MensagemErro"] = ex;
                return View();
            }
        }



        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "ID de livro inválido.";
                return RedirectToAction("Index");
            }

            EmprestimosModelcs emprestimo = _serviceEmprestimo.GetByIdService(id);
            var usuarios = _usuariosService.GetAllUsuarioService().ToList();
            var livros = _livrosService.GetAllLivrosService().ToList();
            ViewBag.Usuarios = usuarios;
            ViewBag.Livros = livros;

            if (emprestimo == null)
            {
                TempData["MensagemErro"] = "Emprestimo não encontrado.";
                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModelcs emprestimo)
        {
            try
            {
                _serviceEmprestimo.EditarEmprestimoService(emprestimo);
                TempData["MensagemSucesso"] = "Edição Realizada com Sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Algum erro ocorreu, contate um administrador"+ex;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "ID de livro inválido.";
                return RedirectToAction("Index");
            }

            EmprestimosModelcs emprestimo = _serviceEmprestimo.GetByIdService(id);
            var usuarios = _usuariosService.GetAllUsuarioService().ToList();
            var livros = _livrosService.GetAllLivrosService().ToList();
            ViewBag.Usuarios = usuarios;
            ViewBag.Livros = livros;

            if (emprestimo == null)
            {
                TempData["MensagemErro"] = "Emprestimo não encontrado.";
                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }


        [HttpPost]
        public IActionResult Excluir(EmprestimosModelcs emprestimo)
        {
            try
            {
                _serviceEmprestimo.RemoverEmprestimoService(emprestimo);
                TempData["MensagemSucesso"] = "Exclusão Realizada com Sucesso";
                return RedirectToAction("Index");
            } catch(InvalidOperationException ex)
            {
                TempData["MensagemErro" ]= ex.Message;
            }
            return View();
        }
  
    }
}
