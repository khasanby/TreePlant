using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.RepositoryInterfaces;

public interface IAreaRepository
{
    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    public Task<bool> AddAsync(IArea area);

    /// <summary>
    /// Gets all areas from db and returns.
    /// </summary>
    public Task<IArea[]> GetAllAsync();

    /// <summary>
    /// Gets area by id from database and throws if expection occurs.
    /// </summary>
    public Task<IArea> GetByIdAsync(int id);

    /// <summary>
    /// Deletes an area entity from db by id.
    /// </summary>
    public Task<bool> DeleteAsync(int id);

    /// <summary>
    /// Updates an area entity in the database.
    /// </summary>
    public Task<bool> UpdateAsync(IArea area);
}
