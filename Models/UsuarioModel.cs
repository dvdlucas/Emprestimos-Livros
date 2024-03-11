using System.ComponentModel.DataAnnotations;

namespace Emprestimos_Livros.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Usuário ! ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o email do Usuário ! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Telefone do Usuário ! ")]
        public string Phone { get; set; }

        public Boolean IsActive { get; set; } = true;

        public ICollection<LivroModel> Livros { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
