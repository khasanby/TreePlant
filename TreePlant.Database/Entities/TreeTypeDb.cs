using System.ComponentModel.DataAnnotations;

namespace TreePlant.Database.Entities;

public sealed class TreeTypeDb
{
    /// <summary>
    /// Gets and sets id of a tree type.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets name of a tree type.
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    /// <summary>
    /// Sets one-to-many relationship
    /// between TreeTypeDb table and TreeSorts table.
    /// </summary>
    public ICollection<TreeSortDb> TreeSorts { get; set; }
}
