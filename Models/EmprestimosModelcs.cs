using System.ComponentModel.DataAnnotations;

namespace Emprestimos_Livros.Models
{
    public class EmprestimosModelcs
    {
        [Key]
        public int Id { get; set; }
        public string Recebedor { get; set; }
        public string Fornecedor { get; set; }
        public string LivroEmprestado { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
