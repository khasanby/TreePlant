using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.RepositoryInterfaces;

public interface ITreePlantRepository
{
    /// <summary>
    /// Adds a new tree to planted trees table in db.
    /// </summary>
    public Task AddAsync(ITreePlant tree);


    /// <summary>
    /// Gets all planted trees in a give area by area id.
    /// </summary>
    public Task<ITreePlant[]> GetPlantedTreesInArea(int areaId);

    /// <summary>
    /// Gets all planted trees from PlantedTrees table.
    /// </summary>
    public Task<ITreePlant[]> GetAllAsync();
}
