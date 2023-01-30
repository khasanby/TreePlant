using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreePlant.Database.DatabaseContext;
using TreePlant.Domain.ModelInterfaces;
using TreePlant.Domain.RepositoryInterfaces;
using TreePlant.Repositories.RepositoryModels;

namespace TreePlant.Repositories.Repositories
{
    public sealed class TreeSortRepository : ITreeSortRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly IMapper _mapper;

        public TreeSortRepository(IDbContextFactory<AppDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the required tree sort by sort id.
        /// </summary>
        public async Task<ITreeSort> GetByIdAsync(int id)
        {
            try
            {
                await using(var dbContext = _contextFactory.CreateDbContext())
                {
                    var treeSort = await dbContext.TreeSorts.FindAsync(id);
                    return _mapper.Map<TreeSort>(treeSort);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
