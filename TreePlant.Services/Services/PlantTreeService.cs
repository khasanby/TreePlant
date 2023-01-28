using TreePlant.Domain.ModelInterfaces;
using TreePlant.Domain.RepositoryInterfaces;
using TreePlant.Domain.ServiceInterfaces;

namespace TreePlant.Services.Services
{
    public sealed class PlantTreeService : IPlantTreeService
    {
        public ITreePlantRepository _treePlantRepository;

        public PlantTreeService(ITreePlantRepository treePlantRepository)
        {
            _treePlantRepository = treePlantRepository;
        }

        /// <summary>
        /// Adds a new tree to planted trees table in db.
        /// </summary>
        public Task<bool> PlantTreeAsync(IPlantedTree tree)
        {
            return _treePlantRepository.AddAsync(tree);
        }
    }
}
