using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Dtos.Responses
{
    public class AutenticarPessoaResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public DateTime DataHoraExpiracao { get; set; }
        public string? Token { get; set; }
    }
}
