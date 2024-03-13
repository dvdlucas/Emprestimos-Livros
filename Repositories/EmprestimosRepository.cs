using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimos_Livros.Repositories
{
    public class EmprestimosRepository
    {
        private readonly ApplicationDbContext _context;

        public EmprestimosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmprestimosModelcs> BuscarTodos()
        {
            return _context.Emprestimos.Include(l => l.Fornecedor).Include(l => l.Recebedor).Include(c => c.Livro).ToList();
        }

        public EmprestimosModelcs Adicionar(EmprestimosModelcs emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
            return emprestimo;
        }

        public bool Remover(EmprestimosModelcs emprestimosModelcs) 
        {
            _context.Emprestimos.Remove(emprestimosModelcs);
            _context.SaveChanges();
            return true;
        }

        public EmprestimosModelcs Editar(EmprestimosModelcs emprestimos)
        {
            _context.Update(emprestimos);
            _context.SaveChanges();
            return emprestimos;
        }

        public EmprestimosModelcs GetById(int? id)
        {
            return _context.Emprestimos.Include(r => r.Recebedor).Include(f => f.Fornecedor).Include(l => l.Livro).FirstOrDefault(x => x.Id == id);
        
        }

        public EmprestimosModelcs GetByIdUserRespository(int? id)
        {
            return _context.Emprestimos
                .Include(e => e.Fornecedor)
                .Include(e => e.Recebedor)
                .FirstOrDefault(x => x.Id == id);
        }


    }
}
