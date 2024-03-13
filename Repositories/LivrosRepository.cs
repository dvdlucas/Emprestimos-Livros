using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimos_Livros.Repositories
{
    public class LivrosRepository
    {
      
        private readonly ApplicationDbContext _context;

        public LivrosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public LivroModel CadastrarLivroRepository(LivroModel livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return livro;
        }

        public List<LivroModel> GetAllLivroRepository()
        {
            return _context.Livros.Include(l => l.Usuario).ToList();
        }

        public LivroModel GetLivroRepositoryById(int? id)
        {
            return _context.Livros.Include(l => l.Usuario).FirstOrDefault(x => x.Id == id);
        }


        public LivroModel EditarLivroRepository(LivroModel livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges ();
            return livro;
        }

        public bool ExcluirLivroRepository(LivroModel livro)
        {
            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<LivroModel> GetLivrosByIdUser(int? id)
        {
            if (id.HasValue && id > 0)
            {
                return _context.Livros.Where(p => p.UsuarioId == id).ToList();
            }

            // Trate a situação em que o id não é válido
            return null; // ou uma lista vazia, dependendo dos requisitos
        }

    }
}
