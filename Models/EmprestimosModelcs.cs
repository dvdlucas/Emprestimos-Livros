using System.ComponentModel.DataAnnotations;

namespace Emprestimos_Livros.Models
{
    public class EmprestimosModelcs
    {
        [Key]
        public int Id { get; set; }

        public int LivroId { get; set; }
        public LivroModel Livro { get; set; }

        public int FornecedorId { get; set; }
        public UsuarioModel Fornecedor { get; set; }

        public int RecebedorId { get; set; }
        public UsuarioModel Recebedor { get; set; }

        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime? DataDevolucao { get; set; } = DateTime.Now.AddDays(10);
    }
}
