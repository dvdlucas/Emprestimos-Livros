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

        public DbSet<LivroModel> Livros { get; set;}

        public DbSet<UsuarioModel> Usuarios { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de chaves estrangeiras
            modelBuilder.Entity<LivroModel>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.Livros)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmprestimosModelcs>()
                .HasOne(e => e.Livro)
                .WithMany(l => l.Emprestimos)
                .HasForeignKey(e => e.LivroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmprestimosModelcs>()
                .HasOne(e => e.Fornecedor)
                .WithMany()
                .HasForeignKey(e => e.FornecedorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmprestimosModelcs>()
                .HasOne(e => e.Recebedor)
                .WithMany()
                .HasForeignKey(e => e.RecebedorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
