using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.ServiceInterfaces;

public interface IAreaService
{
    /// <summary>
    /// Adds a new area entity to the database.
    /// </summary>
    public Task<bool> AddAreaAsync(IArea area);

    /// <summary>
    /// Gets all areas from db and returns.
    /// </summary>
    public Task<IArea[]> GetAllAreasAsync();

    /// <summary>
    /// Gets area by id from database and throws if expection occurs.
    /// </summary>
    public Task<IArea> GetAreaByIdAsync(int id);

    /// <summary>
    /// Deletes an area entity from db by id.
    /// </summary>
    public Task<bool> DeleteAreaAsync(int id);

    /// <summary>
    /// Updates an area entity in the database.
    /// </summary>
    public Task<bool> UpdateAreaAsync(IArea area);
}
