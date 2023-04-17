using Knights.Challenge.Core.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Knights.Challenge.Adapters.Database.MongoDB
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase db;
        private readonly IOptions<MongoDBConfig> config;

        public MongoDBContext(IOptions<MongoDBConfig> config)
        {
            this.config = config;
            var client = new MongoClient(config.Value.ConnectionString);
            db = client.GetDatabase(config.Value.Database);
        }

        public IMongoCollection<KnightEntity> Knights => db.GetCollection<KnightEntity>("Knights");
    }
}
