using TreePlant.Domain.ModelInterfaces;
using TreePlant.Domain.RepositoryInterfaces;
using TreePlant.Domain.ServiceInterfaces;

namespace TreePlant.Services.Services
{
    public sealed class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        /// <summary>
        /// Adds area entity to db.
        /// </summary>
        public Task<bool> AddAreaAsync(IArea area)
        {
            return _areaRepository.AddAsync(area);
        }

        /// <summary>
        /// Deletes area entity from db.
        /// </summary>
        public Task<bool> DeleteAreaAsync(int id)
        {
            return _areaRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Returns all area entities from db.
        /// </summary>
        public Task<IArea[]> GetAllAreasAsync()
        {
            return _areaRepository.GetAllAsync();
        }

        /// <summary>
        /// Returns an area entity by id from db.
        /// </summary>
        public Task<IArea> GetAreaByIdAsync(int id)
        {
            return _areaRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates entity in db.
        /// </summary>
        public Task<bool> UpdateAreaAsync(IArea area)
        {
            return _areaRepository.UpdateAsync(area);
        }
    }
}
