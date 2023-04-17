using Knights.Challenge.Core.Domain.Entities;

namespace Knights.Challenge.Core.Application.Ports
{
    public interface IKnightsRepositoryAdapterPort
    {
        Task CreateAsync(KnightEntity entity);
        Task DeleteAsync(Guid id);
        Task<List<KnightEntity>> GetAllAsync();
        Task<KnightEntity?> GetByIdAsync(Guid id);
        Task UpdateByIdAsync(Guid id, KnightEntity entity);


    }
}
