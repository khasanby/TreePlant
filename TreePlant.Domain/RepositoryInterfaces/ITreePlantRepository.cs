using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.RepositoryInterfaces;

public interface ITreePlantRepository
{
    /// <summary>
    /// Adds a new tree to planted trees table in db.
    /// </summary>
    public Task<bool> AddAsync(IPlantedTree tree);
}
