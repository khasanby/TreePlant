using AutoMapper;
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

    public TreePlantRepository(IDbContextFactory<AppDbContext> contextFactory,IMapper mapper)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a new tree to planted trees table in db.
    /// </summary>
    public async Task<bool> AddAsync(IPlantedTree tree)
    {
        if (tree == null)
        {
            return false;
        }
        await using(var dbContext = _contextFactory.CreateDbContext())
        {
            try
            {
                await dbContext.PlantedTrees.AddAsync(_mapper.Map<PlantedTreeDb>(tree));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}