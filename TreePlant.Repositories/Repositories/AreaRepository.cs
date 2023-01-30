using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreePlant.Database.DatabaseContext;
using TreePlant.Database.Entities;
using TreePlant.Domain.ModelInterfaces;
using TreePlant.Domain.RepositoryInterfaces;
using TreePlant.Repositories.RepositoryModels;

namespace TreePlant.Repositories.Repositories;

public sealed class AreaRepository : IAreaRepository
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;
    private readonly ILogger<AreaRepository> _logger;
    private readonly IMapper _mapper;

    public AreaRepository(IDbContextFactory<AppDbContext> contextFactory,
                          IMapper mapper,
                          ILogger<AreaRepository> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Adds a new entity to the database.
    /// </summary>
    public async Task<bool> AddAsync(IArea area)
    {
        try
        {
            var areaDb = _mapper.Map<AreaDb>(area);
            await using (var context = _contextFactory.CreateDbContext())
            {
                await context.Areas.AddAsync(areaDb);
                await context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.InnerException, $"Class={nameof(AreaRepository)}", $"Method={nameof(AddAsync)}");
            return false;
        }
    }

    /// <summary>
    /// Gets all areas from db and returns.
    /// </summary>
    public async Task<IArea[]> GetAllAsync()
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Areas
                .Include(area => area.Trees)
                .ProjectTo<Area>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }

    /// <summary>
    /// Gets area by id from database and throws if expection occurs.
    /// </summary>
    public async Task<IArea> GetByIdAsync(int id)
    {
        await using (var context = _contextFactory.CreateDbContext())
        {
            var areaDb = await context.Areas.FindAsync(id);
            return _mapper.Map<Area>(areaDb);
        }
    }

    /// <summary>
    /// Deletes an area entity from db by id.
    /// </summary>
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            await using (var context = _contextFactory.CreateDbContext())
            {
                var areaDb = await context.Areas.FindAsync(id);
                context.Areas.Remove(areaDb);
                await context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.InnerException, $"Class={nameof(AreaRepository)}", $"Method={nameof(DeleteAsync)}");
            return false;
        }
    }

    /// <summary>
    /// Updates an area entity in the database.
    /// </summary>
    public async Task<bool> UpdateAsync(IArea area)
    {
        try
        {
            await using (var context = _contextFactory.CreateDbContext())
            {
                var areaDb = await context.Areas.FindAsync(area.Id);
                context.Areas.Update(areaDb);
                await context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.InnerException, $"Class={nameof(AreaRepository)}", $"Method={nameof(UpdateAsync)}");
            return true;
        }
    }
}
