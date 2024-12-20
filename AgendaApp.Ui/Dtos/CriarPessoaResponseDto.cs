namespace AgendaApp.UI.Dtos
{
    /// <summary>
    /// Classe DTO para deserializar os dados obtidos
    /// após o cadastro de pessoa na API
    /// </summary>
    public class CriarPessoaResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}



