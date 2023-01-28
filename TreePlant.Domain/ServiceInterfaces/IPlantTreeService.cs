using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.ServiceInterfaces;

public interface IPlantTreeService
{
    /// <summary>
    /// Adds a new tree to planted trees table in db.
    /// </summary>
    public Task<bool> PlantTreeAsync(IPlantedTree tree);
}
