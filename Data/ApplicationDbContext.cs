using Emprestimos_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimos_Livros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<EmprestimosModelcs> Emprestimos { get; set;}
    }
}
