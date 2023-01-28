using System.ComponentModel.DataAnnotations;

namespace TreePlant.Database.Entities;

public sealed class AreaDb
{
    /// <summary>
    /// Gets and sets if of area.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the size of area.
    /// </summary>
    [Required]
    public double Size { get; set; }

    /// <summary>
    /// Sets one-to-many relationshib with TreeDb table
    /// using lazy loading.
    /// </summary>
    public ICollection<PlantedTreeDb> Trees { get; set; }
}
