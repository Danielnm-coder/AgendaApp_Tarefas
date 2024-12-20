namespace AgendaApp.UI.Dtos
{
    /// <summary>
    /// Classe DTO para deserializar os dados obtidos
    /// após um erro gerado pela API
    /// </summary>
    public class ErrorResponseDto
    {
        public string? Message { get; set; }
    }
}
