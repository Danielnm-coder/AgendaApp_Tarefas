using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);

        void Update(Guid id, T obj);

        void Delete(Guid id);

        List<T> GetAll();

        T? GetById(Guid id);
    }
}
