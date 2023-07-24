using Microsoft.EntityFrameworkCore;
using TvShowsManager.Data.Interfaces;
using TvShowsManager.DataContext;
using TvShowsManager.Models.DataModels;
using TvShowsManager.Models.Enums;

namespace TvShowsManager.Data.Implementations
{
    public class ShowData : IShowData
    {
        private readonly TvShowContext _showContext;

        public ShowData(TvShowContext showContext)
        {
            _showContext = showContext;
        }

        public async Task AddShowAsync(Show show)
        {
            await _showContext.Shows.AddAsync(show);
            await _showContext.SaveChangesAsync();
        }

        public async Task<Show> GetShowByIdAsync(int id)
        {
            var show = await _showContext.Shows.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            return show ?? new Show();
        }

        public async Task<List<Show>> GetShowsByTypeAsync(ShowType showType)
        {
            List<Show> shows = await _showContext.Shows.Where(s => s.ShowType == showType && !s.IsDeleted).ToListAsync();
            return shows;
        }

        public async Task<List<Show>> GetShowByPlatformAsync(Platform platform)
        {
            List<Show> shows = await _showContext.Shows.Where(s => s.Platform == platform && !s.IsDeleted).ToListAsync();
            return shows;
        }

        public async Task<List<Show>> GetShowsAsync()
        {
            List<Show> shows = await _showContext.Shows.Where(s => !s.IsDeleted).ToListAsync();
            return shows;
        }

        public async Task<List<Show>> GetFavoriteShowsAsync()
        {
            List<Show> favoritesShow = await _showContext.Shows.Where(s => s.Favorite && !s.IsDeleted).ToListAsync();
            return favoritesShow;
        }

        public async Task UpdateShowAsync(Show show)
        {
            _showContext.Update(show);
            await _showContext.SaveChangesAsync();
        }
    }
}
