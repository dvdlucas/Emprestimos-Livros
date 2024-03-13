namespace Emprestimos_Livros.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
    }
}