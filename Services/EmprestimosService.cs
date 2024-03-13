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
            if (emprestimo.FornecedorId != emprestimo.RecebedorId)
            {
                emprestimo.Fornecedor = _usuariosRepository.GetById(emprestimo.FornecedorId);
                emprestimo.Recebedor = _usuariosRepository.GetById(emprestimo.RecebedorId);
                emprestimo.Livro = _livrosRepository.GetLivroRepositoryById(emprestimo.LivroId);

                if (emprestimo.Livro.UsuarioId == emprestimo.FornecedorId)
                {
                    emprestimo.Livro.Emprestado = true;
                    return _emprestimosRepository.Adicionar(emprestimo);
                }
                else
                {
                    throw new Exception("Este livro não pertence a esse Fornecedor");
                }
            }
            throw new Exception("Não foi possivel cadastrar emprestimo, Fornecedor deve ser diferente do Recebedor");
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
            emprestimo.Livro = _livrosRepository.GetLivroRepositoryById(emprestimo.LivroId);
            emprestimo.Livro.Emprestado = false;
            return _emprestimosRepository.Remover(emprestimo);
        }

        public EmprestimosModelcs EditarEmprestimoService(EmprestimosModelcs emprestimo)
        {
            return _emprestimosRepository.Editar(emprestimo);

        }

        public EmprestimosModelcs GetByIdUserService(int? id)
        {
            return _emprestimosRepository.GetByIdUserRespository(id);
        }
    }
}
