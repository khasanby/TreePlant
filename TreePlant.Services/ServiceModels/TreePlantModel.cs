using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Services.ServiceModels
{
    public sealed class TreePlantModel : ITreePlant
    {
        /// <summary>
        /// Gets the id of a tree.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the sort name of a tree.
        /// </summary>
        public int TreeSortId { get; set; }

        /// <summary>
        /// Gets and sets the count of trees to plant.
        /// </summary>
        public int TreeCount { get; set; }

        /// <summary>
        /// Gets the area where tree planted.
        /// </summary>
        public int AreaId { get; set; }
    }
}
