namespace TreePlant.Domain.ModelInterfaces;

public interface IArea
{
    /// <summary>
    /// Gets if of area.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the size of area.
    /// </summary>
    public double Size { get; }
}
