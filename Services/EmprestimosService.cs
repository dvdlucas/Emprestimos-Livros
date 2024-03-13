using Emprestimos_Livros.Models;
using Emprestimos_Livros.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Emprestimos_Livros.Services
{
    public class EmprestimosService
    {
        private readonly EmprestimosRepository _emprestimosRepository;
        private readonly LivrosRepository _livrosRepository;
        private readonly UsuariosRepository _usuariosRepository;

        public EmprestimosService(EmprestimosRepository emprestimosRepository, LivrosRepository livrosRepository, UsuariosRepository usuariosRepository)
        {
            _emprestimosRepository = emprestimosRepository;
            _livrosRepository = livrosRepository;
            _usuariosRepository = usuariosRepository;
        }

        public List<EmprestimosModelcs> GetAllEmprestimos()
        {
            return _emprestimosRepository.BuscarTodos();
        }

        public EmprestimosModelcs AdicionarEmprestimo(EmprestimosModelcs emprestimo)
        {
            if (emprestimo.FornecedorId != null && emprestimo.RecebedorId != null && emprestimo.LivroId != null)
            {
                emprestimo.Fornecedor = _usuariosRepository.GetById(emprestimo.FornecedorId);
                emprestimo.Recebedor = _usuariosRepository.GetById(emprestimo.RecebedorId);
                emprestimo.Livro = _livrosRepository.GetLivroRepositoryById(emprestimo.LivroId);

                return _emprestimosRepository.Adicionar(emprestimo);
            }
            throw new Exception("Não foi possivel localizar o emprestimo, contrate um adminstrador");
        }

        public EmprestimosModelcs GetByIdService(int? id)
        {
            EmprestimosModelcs emprestimo = _emprestimosRepository.GetById(id);
            if (emprestimo != null)
            {
                return emprestimo;
            }
            throw new Exception("Não foi possivel localizar o emprestimo, contrate um adminstrador");
        }

        public bool RemoverEmprestimoService(EmprestimosModelcs emprestimo)
        {
            return _emprestimosRepository.Remover(emprestimo);
        }

        public EmprestimosModelcs EditarEmprestimoService(EmprestimosModelcs emprestimo)
        {
               return _emprestimosRepository.Editar(emprestimo);
  
        }
    }
}
