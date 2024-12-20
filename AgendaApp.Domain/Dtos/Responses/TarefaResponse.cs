using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Dtos.Responses
{
    public class TarefaResponse
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
