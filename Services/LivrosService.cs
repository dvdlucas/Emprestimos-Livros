using Emprestimos_Livros.Models;
using Emprestimos_Livros.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Emprestimos_Livros.Services
{
    public class LivrosService
    {
        private readonly LivrosRepository _livrosRepository;
        private readonly UsuariosRepository _usuarioRepository;

        public LivrosService(LivrosRepository livrosRepository, UsuariosRepository usuarioRepository)
        {
            _livrosRepository = livrosRepository;
            _usuarioRepository = usuarioRepository;
        }

        public List<LivroModel> GetAllLivrosService()
        {
            return _livrosRepository.GetAllLivroRepository();
        }

        public LivroModel CadastrarLivroService(LivroModel livro)
        {
            if (livro != null && !string.IsNullOrEmpty(livro.Titulo))
            {

                livro.Usuario = _usuarioRepository.GetById(livro.UsuarioId);

                if (livro.Usuario == null)
                {
                    throw new InvalidOperationException("Usuário não encontrado. Certifique-se de fornecer um usuário válido.");
                }

                // Adicione o livro
                return _livrosRepository.CadastrarLivroRepository(livro);
            }
            else
            {
                throw new InvalidOperationException("Não foi possível adicionar o livro. Certifique-se de fornecer todos os dados necessários.");
            }
        }

        public LivroModel GetLivroServiceById(int? id)
        {
            if (id != null)
            {
                var livro  = _livrosRepository.GetLivroRepositoryById(id);

                if (livro != null)
                {
                    return livro;
                }
                else
                {
                    throw new Exception("Livro não encontrado");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(id), "ID do Livro não pode ser nulo");
            }
        }

        public LivroModel EditarLivroService(LivroModel livro)
        {
            return _livrosRepository.EditarLivroRepository(livro);
        }

        public bool ExcluirLivroService(LivroModel livro)
        {
            return _livrosRepository.ExcluirLivroRepository(livro);
        }


    }
}
