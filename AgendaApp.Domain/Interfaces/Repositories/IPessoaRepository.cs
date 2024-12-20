using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        bool VerifyExists(string email);

        Pessoa? Get(string email, string senha);
    }
}
