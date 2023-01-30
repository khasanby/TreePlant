using Microsoft.EntityFrameworkCore;
using TreePlant.Database.Entities;

namespace TreePlant.Database.DatabaseContext
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Areas table.
        /// </summary>
        public DbSet<AreaDb> Areas { get; set; }

        /// <summary>
        /// Tree types table.
        /// </summary>
        public DbSet<TreeSortDb> TreeSorts { get; set; }

        /// <summary>
        /// Planted Trees table.
        /// </summary>
        public DbSet<TreePlantDb> PlantedTrees { get; set; }

        /// <summary>
        /// Tree types table.
        /// </summary>
        public DbSet<TreeTypeDb> TreeTypes { get; set; }
    }
}
