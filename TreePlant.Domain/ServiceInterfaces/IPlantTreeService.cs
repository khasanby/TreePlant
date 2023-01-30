using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.ServiceInterfaces;

public interface IPlantTreeService
{
    /// <summary>
    /// Adds a new tree to planted trees table in db.
    /// </summary>
    public Task<bool> PlantTreeAsync(ITreePlant tree);

    /// <summary>
    /// Gets all planted trees from PlantedTrees table.
    /// </summary>
    public Task<ITreePlant[]> GetPlantedTreesAsync();

    /// <summary>
    /// Gets all planted trees in a give area by area id.
    /// </summary>
    public Task<ITreePlant[]> GetPlantedTreesInArea(int areaId);
}
