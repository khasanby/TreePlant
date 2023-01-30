namespace TreePlant.Domain.ModelInterfaces;

public interface ITreePlant
{
    /// <summary>
    /// Gets the id of a tree.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the sort name of a tree.
    /// </summary>
    public int TreeSortId { get; }

    /// <summary>
    /// Gets and sets count of tree to plant.
    /// </summary>
    public int TreeCount { get; set; }

    /// <summary>
    /// Gets thes area where tree planted.
    /// </summary>
    public int AreaId { get; }
}
