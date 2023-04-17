using Knights.Challenge.Core.Application.Ports;
using Knights.Challenge.Core.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Knights.Challenge.Adapters.Database.MongoDB.Repositories
{
    public class KnightsRepositoryAdapter : MongoDBRepository<KnightEntity>, IKnightsRepositoryAdapterPort
    {
        private readonly ILogger<KnightsRepositoryAdapter> logger;
        public KnightsRepositoryAdapter(IMongoDBContext context, ILogger<KnightsRepositoryAdapter> logger) : base(context.Knights)
        {
            this.logger = logger;
        }
        public async Task CreateAsync(KnightEntity entity)
        {
            logger.LogInformation("Creating collection Knight...");
            await collection.InsertOneAsync(entity);
        }

        public async Task<List<KnightEntity>> GetAllAsync()
        {
            logger.LogInformation("Find all collections Knight...");
            return await FindAllAsync();
        }
                    
        public async Task<KnightEntity?> GetByIdAsync(Guid id)
        {
            logger.LogInformation("Find by id collection Knight...");
            return await FindByIdAsync(id);
        }

        public async Task UpdateByIdAsync(Guid id, KnightEntity entity)
        {
            logger.LogInformation($"Updating collection Knight Id: {id} ...");
            await UpdatedAsync(id, entity);
        }
    }
}
