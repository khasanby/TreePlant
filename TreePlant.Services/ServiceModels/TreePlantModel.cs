using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Services.ServiceModels
{
    public sealed class TreePlantModel : IPlantedTree
    {
        /// <summary>
        /// Gets the id of a tree.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the sort name of a tree.
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// Gets the area where tree planted.
        /// </summary>
        public int AreaId { get; set; }
    }
}
