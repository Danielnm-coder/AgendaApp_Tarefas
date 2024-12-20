using AgendaApp.UI.Dtos;
using System.ComponentModel.DataAnnotations;

namespace AgendaApp.UI.Models
{
    public class ConsultarTarefaViewModel
    {
        [Required(ErrorMessage = "Por favor, informe a data de início.")]
        public string? DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de término.")]
        public string? DataFim { get; set; }

        public List<TarefaResponseDto>? Tarefas { get; set; }
    }
}

