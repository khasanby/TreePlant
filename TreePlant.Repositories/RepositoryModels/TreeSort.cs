using TreePlant.Domain.Enums;
using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Repositories.RepositoryModels;

internal sealed class TreeSort : ITreeSort
{
    /// <summary>
    /// Gets and internally sets the id of a sort.
    /// </summary>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets and internally sets the name of a sort.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Gets and internally sets hegiht (CM) of a tree when it is fully mature.
    /// </summary>
    public double MatureHeightCm { get; internal set; }

    /// <summary>
    /// Gets and internally sets and width (CM) of a tree when it is fully mature.
    /// </summary>
    public double MatureWidthCm { get; internal set; }

    /// <summary>
    /// Gets and internally sets the growth rate of a tree per year (in cm).
    /// </summary>
    public double GrowthRateCm { get; internal set; }

    /// <summary>
    /// Gets and internally sets the harvest time of a tree.
    /// </summary>
    public HarvestTime HarvestTime { get; internal set; }

    /// <summary>
    /// Gets and internally sets the required soil type for a tree.
    /// </summary>
    public SoilTypes SoilType { get; internal set; }

    /// <summary>
    /// Gets and internally sets the required sun exposure type for a tree.
    /// </summary>
    public SunExposures SunExposure { get; internal set; }

    /// <summary>
    /// Gets and internally sets the average bear age for a tree.
    /// </summary>
    public int BearingAge { get; internal set; }

    /// <summary>
    /// Gets and internally sets the price of a single tree.
    /// </summary>
    public double Price { get; internal set; }

    /// <summary>
    /// Gets and internally sets type of a tree.
    /// </summary>
    public int TreeTypeId { get; internal set; }
}
