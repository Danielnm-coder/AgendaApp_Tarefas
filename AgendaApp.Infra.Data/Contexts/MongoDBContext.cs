using AgendaApp.Domain.Entities;
using AgendaApp.Infra.Data.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgendaApp.Infra.Data.Contexts
{
    public class MongoDBContext<T> where T : class
    {
        private readonly IMongoDatabase? _database;
        private readonly string? _collectionName;

        /// <summary>
        /// Método construtor para abrir conexão com o banco de dados do MongoDB
        /// </summary>
        public MongoDBContext(string collectionName)
        {
            var clientSettings = MongoClientSettings.FromUrl(new MongoUrl(MongoDBSettings.Host));
            var mongoClient = new MongoClient(clientSettings);

            _database = mongoClient.GetDatabase(MongoDBSettings.Database);
            _collectionName = collectionName;
        }

        /// <summary>
        /// Método para realizar operações como uma coleção (entidade)
        /// do mongodb (utilizando tipo genérico)
        /// </summary>
        public IMongoCollection<T>? Collection {
            get {
                return _database?.GetCollection<T>(_collectionName);
            }            
        }
    }
}
