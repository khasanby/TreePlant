using AutoMapper;
using TreePlant.Repositories.RepositoryModels;
using TreePlant.Domain.ModelInterfaces;
using TreePlant.Database.Entities;

namespace TreePlant.Repositories.AutoMapper
{
    public sealed class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IArea, AreaDb>()
                .ForMember(dest => dest.Size, opt =>
                           opt.MapFrom(src => src.Size));
            CreateMap<AreaDb, Area>()
                .ForMember(dest => dest.Size, opt =>
                           opt.MapFrom(src => src.Size));
            CreateMap<IPlantedTree, PlantedTreeDb>()
                .ForMember(dest => dest.AreaId, opt =>
                           opt.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.TreeSortId, opt =>
                           opt.MapFrom(src => src.SortId));
            CreateMap<PlantedTreeDb, IPlantedTree>()
                .ForMember(dest => dest.AreaId, opt =>
                           opt.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.SortId, opt =>
                           opt.MapFrom(src => src.TreeSortId));
        }
    }
}
