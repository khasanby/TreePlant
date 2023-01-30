using TreePlant.Domain.ModelInterfaces;

namespace TreePlant.Domain.RepositoryInterfaces
{
    public interface ITreeSortRepository
    {
        /// <summary>
        /// Gets the required tree sort by sort id.
        /// </summary>
        public Task<ITreeSort> GetByIdAsync(int id);
    }
}
