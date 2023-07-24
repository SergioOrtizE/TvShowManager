using TvShowsManager.Models.Enums;
using TvShowsManager.Models.ViewModels;

namespace TvShowsManager.Services.Interfaces
{
    public interface IShowService
    {
        Task CreateShowAsync(ShowViewModel show);

        Task<List<ShowViewModel>> GetShowsByTypeAsync(ShowType showType);

        Task<List<ShowViewModel>> GetShowsByPlatformAsync(Platform platform);

        Task<List<ShowViewModel>> GetShowsAsync();

        Task<List<ShowViewModel>> GetFavoriteShowsAsync();

        Task SetShowFavoriteStatusByIdAsync(int id);

        Task DeleteShowAsync(int id);
    }
}
