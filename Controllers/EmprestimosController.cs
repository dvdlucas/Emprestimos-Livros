using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Emprestimos_Livros.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimos_Livros.Controllers
{
    public class EmprestimosController : Controller
    {
        readonly private EmprestimosService _serviceEmprestimo;
   
        public EmprestimosController(EmprestimosService serviceEmprestimo)
        {
            _serviceEmprestimo = serviceEmprestimo;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModelcs> emprestimos = _serviceEmprestimo.GetAllEmprestimos();
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
            try
            {
                if (ModelState.IsValid)
                {
                    _serviceEmprestimo.AdicionarEmprestimo(emprestimo);
                    TempData["MensagemSucesso"] = "Cadastro Realizado com Sucesso";
                    return RedirectToAction("Index");
                }
            }
            catch (InvalidOperationException ex)
            {
                TempData["MensagemErro"] = ex.Message;
            }

            return View();
        }



        [HttpGet]
        public IActionResult Editar(int? id)
        {
            EmprestimosModelcs emprestimo = _serviceEmprestimo.GetByIdService(id);
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModelcs emprestimo)
        {
            if (ModelState.IsValid)
            {
                _serviceEmprestimo.EditarEmprestimoService(emprestimo);
                TempData["MensagemSucesso"] = "Edição Realizada com Sucesso";
                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "Algum erro ocorreu, contate um administrador";

            return View(emprestimo);

        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            EmprestimosModelcs emprestimo = _serviceEmprestimo.GetByIdService(id);
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
