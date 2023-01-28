using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TreePlant.Domain.Enums;

namespace TreePlant.Database.Entities;

public sealed class TreeSortDb
{
    /// <summary>
    /// Gets and sets id of a sort.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets name of a sort.
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    /// <summary>
    /// Gets and sets hegiht of a tree when it is fully mature.
    /// </summary>
    public double MatureHeight { get; set; }

    /// <summary>
    /// Gets and sets width of a tree when it is fully mature.
    /// </summary>
    public double MatureWidth { get; set; }

    /// <summary>
    /// Gets and sets the growth rate of a tree per year (in cm).
    /// </summary>
    public double GrowthRateCm { get; set; }

    /// <summary>
    /// Gets and sets the harvest time of a tree.
    /// </summary>
    public HarvestTime HarvestTime { get; set; }

    /// <summary>
    /// Gets and sets the required soil type for a tree.
    /// </summary>
    public string SoilType { get; set; }

    /// <summary>
    /// Gets and sets the required sun exposure type for a tree.
    /// </summary>
    public string SunExposure { get; set; }

    /// <summary>
    /// Gets and sets the average bear age for a tree.
    /// </summary>
    public int BearingAge { get; set; }

    /// <summary>
    /// Gets and sets the price of a single tree.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Gets and sets type id foreign key reference.
    /// </summary>
    [ForeignKey(nameof(TreeTypeDb))]
    public int TreeTypeId { get; set; }

    /// <summary>
    /// Sets foreign key reference to TreeTypeDb table.
    /// </summary>
    public TreeTypeDb TreeType { get; set; }
}
