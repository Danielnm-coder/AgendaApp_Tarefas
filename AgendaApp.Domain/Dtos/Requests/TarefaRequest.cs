using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Dtos.Requests
{
    public class TarefaRequest
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public int? Prioridade { get; set; }
    }
}
