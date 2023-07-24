using TvShowsManager.Models.DataModels;
using TvShowsManager.Models.Enums;

namespace TvShowsManager.Data.Interfaces
{
    public interface IShowData
    {
        Task AddShowAsync(Show show);

        Task<Show> GetShowByIdAsync(int id);

        Task<List<Show>> GetShowsByTypeAsync(ShowType showType);

        Task<List<Show>> GetShowByPlatformAsync(Platform platform);

        Task<List<Show>> GetShowsAsync();

        Task<List<Show>> GetFavoriteShowsAsync();

        Task UpdateShowAsync(Show show);
    }
}
