using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Dtos.Requests
{
    public class AutenticarPessoaRequest
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
