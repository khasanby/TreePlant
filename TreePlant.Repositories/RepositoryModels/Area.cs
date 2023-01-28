using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Repositories.RepositoryModels;

internal class Area : IArea
{
    /// <summary>
    /// Gets and internally sets if of area.
    /// </summary>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets and internally sets the size of area.
    /// </summary>
    public double Size { get; internal set; }
}
