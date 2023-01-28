namespace TreePlant.Domain.ModelInterfaces;

public interface ITreeType
{
    /// <summary>
    /// Gets and sets id of a tree type.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets and sets name of a tree type.
    /// </summary>
    public string Name { get; }
}
