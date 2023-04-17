using Knights.Challenge.Core.Application.Contracts;

namespace Knights.Challenge.Core.Application.Services
{
    public interface IKnightService
    {
        Task CreateAsync(KnightRequest request);
        Task<List<KnightResponse>> GetAllAsync();
        Task UpdateAsync(Guid id, string nickName);
        Task DeleteAsync(Guid id);
        Task<KnightResponse?> GetByIdAsync(Guid id);
    }
}
