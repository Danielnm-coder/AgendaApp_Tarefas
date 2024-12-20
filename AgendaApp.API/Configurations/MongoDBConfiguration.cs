using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;

namespace AgendaApp.API.Configurations
{
    /// <summary>
    /// Classe para configurações do MongoDB
    /// </summary>
    public class MongoDBConfiguration
    {
        public static void AddMongoDBConfiguration()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Guid)))
            {
                BsonSerializer.RegisterSerializer
                    (new GuidSerializer(MongoDB.Bson.BsonType.String));
            }
        }
    }
}



