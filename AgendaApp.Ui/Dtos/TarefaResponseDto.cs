namespace AgendaApp.UI.Dtos
{
    public class TarefaResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public PrioridadeResponse? Prioridade { get; set; }
    }

    public class PrioridadeResponse
    {
        public int Valor { get; set; }
        public string? Nome { get; set; }
    }
}



