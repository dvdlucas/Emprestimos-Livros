using Emprestimos_Livros.Models;
using Emprestimos_Livros.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimos_Livros.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuariosServices _services;

        public UsuariosController(UsuariosServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            IEnumerable<UsuarioModel> usuarios = _services.GetAllUsuarioService();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {

            _services.CadastrarUsuarioService(usuario);
            TempData["MensagemSucesso"] = "Cadastro Realizado com Sucesso";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            UsuarioModel usuario = _services.GetByIdService(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Excluir(UsuarioModel usuario)
        {
            if (usuario.Livros.Count > 0)
            {

                _services.ExcluirUsuarioService(usuario);
                TempData["MensagemSucesso"] = "Exclusão Realizada com Sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = "Este usuário não pode ser excluído pois possui livros cadastrados";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                TempData["MensagemErro"] = "ID de usuário inválido.";
                return RedirectToAction("Index");
            }

            UsuarioModel usuario = _services.GetByIdService(id);

            if (usuario == null)
            {
                TempData["MensagemErro"] = "Usuário não encontrado.";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                _services.EditarUsuarioService(usuario);
                TempData["MensagemSucesso"] = "Edição Realizada com Sucesso";
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return View(usuario);
            }
        }
    }
}
