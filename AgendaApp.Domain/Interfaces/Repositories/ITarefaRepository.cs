using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        List<Tarefa> Get(DateTime dataMin, DateTime dataMax, Guid pessoaId);

        Tarefa? Get(Guid tarefaId, Guid pessoaId);
    }
}
