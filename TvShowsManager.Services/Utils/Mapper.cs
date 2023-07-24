using AutoMapper;
using TvShowsManager.Models.DataModels;
using TvShowsManager.Models.Enums;
using TvShowsManager.Models.Utils;
using TvShowsManager.Models.ViewModels;

namespace TvShowsManager.Services.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Show, ShowViewModel>().ForMember(dest => dest.Platform,
                opt => opt.MapFrom(src => src.Platform.GetDescription()))
                .ForMember(dest => dest.ShowType,
                opt => opt.MapFrom(src => src.ShowType.GetDescription()))
                .ForMember(dest => dest.Favorite,
                opt => opt.MapFrom(src => src.Favorite ? "*" : string.Empty));
            CreateMap<ShowViewModel, Show>().ForMember(dest => dest.Platform,
                opt => opt.MapFrom(src => Enum.Parse(typeof(Platform), src.Platform)))
                .ForMember(dest => dest.ShowType,
                opt => opt.MapFrom(src => Enum.Parse(typeof(ShowType), src.ShowType)))
                .ForMember(dest => dest.Favorite,
        opt => opt.MapFrom(src => src.Favorite == "*"));
        }
    }
}
