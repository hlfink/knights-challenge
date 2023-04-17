using Knights.Challenge.Core.Domain.Entities;
using MongoDB.Driver;

namespace Knights.Challenge.Adapters.Database.MongoDB
{
    public interface IMongoDBContext
    {
        IMongoCollection<KnightEntity> Knights { get; }

    }
}
