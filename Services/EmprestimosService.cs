using Emprestimos_Livros.Models;
using Emprestimos_Livros.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Emprestimos_Livros.Services
{
    public class EmprestimosService
    {
        private readonly EmprestimosRepository _emprestimosRepository;

        public EmprestimosService(EmprestimosRepository emprestimosRepository)
        {
            _emprestimosRepository = emprestimosRepository;
        }

        public List<EmprestimosModelcs> GetAllEmprestimos()
        {
            return _emprestimosRepository.BuscarTodos();
        }

        public EmprestimosModelcs AdicionarEmprestimo(EmprestimosModelcs emprestimo)
        {
            if (emprestimo.LivroEmprestado != null && emprestimo.Recebedor != null && emprestimo.Fornecedor != null)
            {
                return _emprestimosRepository.Adicionar(emprestimo);
            }
            throw new InvalidOperationException("Não foi possivel adicionar o emprestimo, contrate um adminstrador");
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
