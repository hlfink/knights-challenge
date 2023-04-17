using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace Knights.Challenge.Adapters.Database.MongoDB
{
    public abstract class MongoDBRepository<TClass>
    {
        internal IMongoCollection<TClass> collection { get; }

        public MongoDBRepository(IMongoCollection<TClass> collection)
        {
            this.collection = collection;
        }

        public Task<List<TClass>> FindAllAsync()
        {
            return Task.FromResult(collection.Find(new BsonDocument()).ToList());
        }

        public Task<List<TClass>> FindByElementAsync(string element, string value)
        {
            var filterBuilder = Builders<TClass>.Filter;

            var filterDef = filterBuilder.Eq($"{element}", value);

            var entities = collection.Find(filterDef).ToList();

            return Task.FromResult(entities);
        }
        public Task<TClass> FindByManyElementsAsync(Dictionary<string, string> filter)
        {
            var filterBuilder = Builders<TClass>.Filter;
            var filterDef = Builders<TClass>.Filter.Empty;

            foreach (var item in filter)
                filterDef &= filterBuilder.Eq($"{item.Key}", item.Value);

            var entities = collection.Find(filterDef).FirstOrDefault();

            return Task.FromResult(entities);
        }
        public async Task DeleteAsync(Guid id)
        {
            var filterBuilder = Builders<TClass>.Filter;

            var filterDef = filterBuilder.Eq("_id", id);
            await collection.DeleteOneAsync(filterDef);
        }
        public async Task UpdatedAsync(Guid id, TClass entity)
        {
            var filterBuilder = Builders<TClass>.Filter;
            var filterDef = filterBuilder.Eq("_id", id);

            await collection.ReplaceOneAsync(filterDef, entity);
        }

        public Task<TClass> FindByIdAsync(Guid id)
        {
            var filter = Builders<TClass>.Filter.Eq(new StringFieldDefinition<TClass, Guid>("_id"), id);
            var entity = collection.Find(filter).FirstOrDefault();
            
            return Task.FromResult(entity);
        }
    }
}
