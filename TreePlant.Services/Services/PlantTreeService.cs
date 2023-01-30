using Microsoft.Extensions.Logging;
using TreePlant.Domain.ModelInterfaces;
using TreePlant.Domain.RepositoryInterfaces;
using TreePlant.Domain.ServiceInterfaces;

namespace TreePlant.Services.Services
{
    public sealed class PlantTreeService : IPlantTreeService
    {
        private readonly ITreePlantRepository _treePlantRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly ITreeSortRepository _treeSortRepository;
        private ILogger<PlantTreeService> _logger;

        public PlantTreeService(ITreePlantRepository treePlantRepository,
                                IAreaRepository areaRepository,
                                ITreeSortRepository treeSortRepository,
                                ILogger<PlantTreeService> logger)
        {
            _treePlantRepository = treePlantRepository;
            _areaRepository = areaRepository;
            _logger = logger;
            _treeSortRepository = treeSortRepository;
        }

        /// <summary>
        /// Adds a new tree to planted trees table in db.
        /// </summary>
        public Task<bool> PlantTreeAsync(ITreePlant treesToPlant)
        {
            if (CheckIfAreaAvailable(treesToPlant))
            {
                _treePlantRepository.AddAsync(treesToPlant);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        /// <summary>
        /// Gets all planted trees from PlantedTrees table.
        /// </summary>
        public Task<ITreePlant[]> GetPlantedTreesAsync()
        {
            return _treePlantRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets all planted trees in a give area by area id.
        /// </summary>
        public Task<ITreePlant[]> GetPlantedTreesInArea(int areaId)
        {
            return _treePlantRepository.GetPlantedTreesInArea(areaId);
        }

        #region Private Methods
        /// <summary>
        /// Checks if area size is enough to plant trees.
        /// </summary>
        private bool CheckIfAreaAvailable(ITreePlant treeToPlant)
        {
            // Gets the area where user selected to plant.
            var areaToPlant = _areaRepository.GetByIdAsync(treeToPlant.AreaId).GetAwaiter().GetResult();

            // Get available area by counting total width of trees in the area.
            var availableArea = GetAvailableAreaSize(areaToPlant);
            var treeSort = GetTreeSortAsync(treeToPlant.TreeSortId).GetAwaiter().GetResult();

            // Find required area by subtracting planted total trees width from just entered trees total width.
            var requiredArea = treeToPlant.TreeCount * (treeSort.MatureWidthCm / 100);

            return availableArea > requiredArea;
        }

        /// <summary>
        /// Returns available area in the area.
        /// </summary>
        private double GetAvailableAreaSize(IArea area)
        {
            try
            {
                // Finds what trees already planted in that area.
                var plantedTreesInArea = _treePlantRepository.GetPlantedTreesInArea(area.Id).GetAwaiter().GetResult();
                var areaSize = area.Size;
                foreach (var tree in plantedTreesInArea)
                {
                    var treeSort = GetTreeSortAsync(tree.TreeSortId).GetAwaiter().GetResult();
                    areaSize -= tree.TreeCount * (treeSort.MatureWidthCm / 100);
                }
                return areaSize;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, $"Class={nameof(PlantTreeService)}", $"Method={nameof(GetAvailableAreaSize)}");
                return 0;
            }
        }

        /// <summary>
        /// Gets the proper tree sort by sort id.
        /// </summary>
        private Task<ITreeSort> GetTreeSortAsync(int sortId)
        {
            return _treeSortRepository.GetByIdAsync(sortId);
        }
        #endregion
    }
}
