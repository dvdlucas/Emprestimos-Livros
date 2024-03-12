using System.ComponentModel.DataAnnotations;

namespace Emprestimos_Livros.Models
{
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Livro ! ")]
        public string Titulo { get; set; }

        public Boolean Emprestado { get; set; } = false;

        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

        public ICollection<EmprestimosModelcs> Emprestimos { get; set; }
    }
}
