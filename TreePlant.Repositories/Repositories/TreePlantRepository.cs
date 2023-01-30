using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreePlant.Database.DatabaseContext;
using TreePlant.Database.Entities;
using TreePlant.Domain.ModelInterfaces;
using TreePlant.Domain.RepositoryInterfaces;

namespace TreePlant.Repositories.Repositories;

public sealed class TreePlantRepository : ITreePlantRepository
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    private readonly IMapper _mapper;
    ILogger<TreePlantRepository> _logger;

    public TreePlantRepository(IDbContextFactory<AppDbContext> contextFactory,
                                IMapper mapper,
                                ILogger<TreePlantRepository> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Adds a new tree to planted trees table in db.
    /// </summary>
    public async Task AddAsync(ITreePlant tree)
    {
        await using (var dbContext = _contextFactory.CreateDbContext())
        {
            try
            {
                await dbContext.PlantedTrees.AddAsync(_mapper.Map<TreePlantDb>(tree));
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException, $"Class={nameof(TreePlantRepository)}", $"Method={nameof(AddAsync)}");
            }
        }
    }

    /// <summary>
    /// Gets all planted trees in a give area by area id.
    /// </summary>
    public async Task<ITreePlant[]> GetPlantedTreesInArea(int areaId)
    {
        try
        {
            await using (var dbContext = _contextFactory.CreateDbContext())
            {
                var plantedTrees = await dbContext.PlantedTrees.Where(c => c.AreaId == areaId)
                    .ProjectTo<TreePlant.Repositories.RepositoryModels.TreePlant>(_mapper.ConfigurationProvider).ToArrayAsync();
                return plantedTrees;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    /// <summary>
    /// Gets all planted trees from PlantedTrees table.
    /// </summary>
    public async Task<ITreePlant[]> GetAllAsync()
    {
        try
        {
            await using (var dbContext = _contextFactory.CreateDbContext())
            {
                var plantedTrees = await dbContext.PlantedTrees
                    .ProjectTo<TreePlant.Repositories.RepositoryModels.TreePlant>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();
                return plantedTrees;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}