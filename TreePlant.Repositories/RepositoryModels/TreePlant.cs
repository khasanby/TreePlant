using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Repositories.RepositoryModels;

internal sealed class TreePlant : ITreePlant
{
    /// <summary>
    /// Gets and internal sets id of a tree.
    /// </summary>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets and internal sets sort id of a tree.
    /// </summary>
    public int TreeSortId { get; internal set; }

    /// <summary>
    /// Gets and sets count of tree to plant.
    /// </summary>
    public int TreeCount { get; set; }

    /// <summary>
    /// Gets and internal sets area id where tree planted.
    /// </summary>
    public int AreaId { get; internal set; }
}