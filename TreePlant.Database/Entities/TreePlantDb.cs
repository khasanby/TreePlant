using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreePlant.Database.Entities;

public sealed class TreePlantDb
{
    /// <summary>
    /// Gets and sets id of a tree.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Sets foreign key reference to TreeSort table.
    /// </summary>
    [ForeignKey(nameof(TreeSortDb))]
    public int TreeSortId { get; set; }

    /// <summary>
    /// Gets and sets count of planted tree.
    /// </summary>
    public int TreeCount { get; set; }

    /// <summary>
    /// Gets and sets tree sort.
    /// </summary>
    public TreeSortDb TreeSort { get; set; }

    /// <summary>
    /// Sets foreign key reference to Area table.
    /// </summary>
    [ForeignKey(nameof(AreaDb))]
    public int AreaId { get; set; }

    /// <summary>
    /// Gets and sets area where tree in.
    /// </summary>
    public AreaDb Area { get; set; }
}