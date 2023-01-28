using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Services.ServiceModels
{
    public sealed class AreaCreate : IArea
    {
        /// <summary>
        /// Gets and sets id of an area.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets and sets size of an area.
        /// </summary>
        public double Size { get; set; }
    }
}
