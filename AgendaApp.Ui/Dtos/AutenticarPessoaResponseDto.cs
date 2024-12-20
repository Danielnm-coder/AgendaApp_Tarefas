namespace AgendaApp.Ui.Dtos
{
    public class AutenticarPessoaResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public DateTime DataHoraExpiracao { get; set; }
        public string? Token { get; set; }

    }
}
