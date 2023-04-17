using Knights.Challenge.Core.Application.Contracts;
using Knights.Challenge.Core.Application.Ports;
using Knights.Challenge.Core.Domain.Entities;

namespace Knights.Challenge.Core.Application.Services
{
    public class KnightService : IKnightService
    {
        private IKnightsRepositoryAdapterPort adapterPort;
        public KnightService(IKnightsRepositoryAdapterPort adapterPort)
        {
            this.adapterPort = adapterPort;
        }
        public async Task CreateAsync(KnightRequest request)
        {
            await adapterPort.CreateAsync(request);
        }
        public async Task DeleteAsync(Guid id)
        {
            await adapterPort.DeleteAsync(id);
        }
        public async Task<List<KnightResponse>> GetAllAsync()
        {
            var list = await adapterPort.GetAllAsync();

            return Mapper(list);
        }
        public async Task<KnightResponse?> GetByIdAsync(Guid id)
        {
            var entity = await adapterPort.GetByIdAsync(id);

            return MapperEntityToResponse(entity);
        }
        public async Task UpdateAsync(Guid id, string nickName)
        {
            var entity = await adapterPort.GetByIdAsync(id);

            if (entity == null) { throw new Exception("knight not found..."); }

            entity.NickName = nickName;

            await adapterPort.UpdateByIdAsync(id, entity);
        }
        private List<KnightResponse> Mapper(List<KnightEntity> list)
        {
            return list.ConvertAll(x => MapperEntityToResponse(x) ?? new KnightResponse()) ;
        }

        private KnightResponse? MapperEntityToResponse(KnightEntity? entity)
        {
            if (entity == null) {  return null; }

            return new KnightResponse
            {
                Id = entity.Id.ToString(),
                NickName = entity.NickName,
                Attribute = entity.KeyAttribute,
                Age = entity.GetAge(),
                Attack = entity.GetAttack(),
                Experiense = entity.GetExperiense(),
                Name = entity.Name,
                Weapons = entity.Weapons.Count(),
            };
        }
    }
}
