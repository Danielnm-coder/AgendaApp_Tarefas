using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Atributo para gerar a conexão com o banco de dados
        /// </summary>
        protected readonly MongoDBContext<T> _context;

        /// <summary>
        /// Construtor para passarmos o nome da collection (entidade)
        /// que o repositório genérico deverá acessar no banco de dados do MongoDB
        /// </summary>
        public BaseRepository(string collectionName)
        {
            _context = new MongoDBContext<T>(collectionName);
        }

        public virtual void Add(T obj)
        {
            _context?.Collection?.InsertOne(obj);
        }

        public virtual void Update(Guid id, T obj)
        {
            _context?.Collection?.ReplaceOne(Builders<T>.Filter.Eq("_id", id), obj);
        }

        public virtual void Delete(Guid id)
        {
            _context?.Collection?.DeleteOne(Builders<T>.Filter.Eq("_id", id));

            /*
            var filter = Builders<T>.Filter.Eq("_id", id);
            var update = Builders<T>.Update.Set("ativo", false);

            _context?.Collection?.UpdateOne(filter, update);
            */
        }

        public virtual List<T> GetAll()
        {
            return _context?.Collection?.Find(_ => true).ToList();
        }

        public virtual T? GetById(Guid id)
        {
            return _context?.Collection?.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefault();
        }
    }
}
