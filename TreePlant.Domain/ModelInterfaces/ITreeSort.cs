using TreePlant.Domain.Enums;

namespace TreePlant.Domain.ModelInterfaces;

public interface ITreeSort
{
    /// <summary>
    /// Gets id of a sort.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the name of a sort.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets hegiht (CM) of a tree when it is fully mature.
    /// </summary>
    public double MatureHeightCm { get; }

    /// <summary>
    /// Gets and width (CM) of a tree when it is fully mature.
    /// </summary>
    public double MatureWidthCm { get; }

    /// <summary>
    /// Gets the growth rate of a tree per year (in cm).
    /// </summary>
    public double GrowthRateCm { get; }

    /// <summary>
    /// Gets the harvest time of a tree.
    /// </summary>
    public HarvestTime HarvestTime { get; }

    /// <summary>
    /// Gets the required soil type for a tree.
    /// </summary>
    public SoilTypes SoilType { get; }

    /// <summary>
    /// Gets the required sun exposure type for a tree.
    /// </summary>
    public SunExposures SunExposure { get; }

    /// <summary>
    /// Gets the average bear age for a tree.
    /// </summary>
    public int BearingAge { get; }

    /// <summary>
    /// Gets the price of a single tree.
    /// </summary>
    public double Price { get; }

    /// <summary>
    /// Gets and sets type of a tree.
    /// </summary>
    public int TreeTypeId { get; }
}
