namespace TreePlant.Domain.ModelInterfaces;

public interface IPlantedTree
{
    /// <summary>
    /// Gets id of a tree.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets sort name of a tree.
    /// </summary>
    public int SortId { get; }

    /// <summary>
    /// Gets area where tree planted.
    /// </summary>
    public int AreaId { get; }
}
