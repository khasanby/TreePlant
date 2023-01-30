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
            // Mapping from IArea to AreaDb.
            CreateMap<IArea, AreaDb>();

            // Mapping from AreaDb to Area.
            CreateMap<AreaDb, Area>();
            
            // Mapping from ITreePlant to TreePlantDb.
            CreateMap<ITreePlant, Database.Entities.TreePlantDb>()
                .ForMember(dest => dest.AreaId, opt =>
                           opt.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.TreeSortId, opt =>
                           opt.MapFrom(src => src.TreeSortId))
                .ForMember(dest => dest.TreeCount, opt =>
                           opt.MapFrom(src => src.TreeCount));


            // Mapping from TreePlantDb to ITreePlant.
            CreateMap<Database.Entities.TreePlantDb, TreePlant.Repositories.RepositoryModels.TreePlant>()
                .ForMember(dest => dest.AreaId, opt =>
                           opt.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.TreeSortId, opt =>
                           opt.MapFrom(src => src.TreeSortId))
                .ForMember(dest => dest.TreeCount, opt =>
                           opt.MapFrom(src => src.TreeCount));

            // Map from TreeSortDb to ITreeSort
            CreateMap<TreeSortDb, TreeSort>();

            // Map from ITreeSort to TreeSortDb
            CreateMap<ITreeSort, TreeSortDb>();
        }
    }
}
