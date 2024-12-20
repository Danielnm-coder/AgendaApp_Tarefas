using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Entities
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        #region Relacionamentos

        public List<Tarefa>? Tarefas { get; set; }

        #endregion
    }
}
