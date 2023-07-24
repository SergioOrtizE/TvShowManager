using TvShowsManager.Models.DataModels;
using TvShowsManager.Services.Interfaces;
using TvShowsManager.Data.Interfaces;
using TvShowsManager.Models.Enums;
using AutoMapper;
using TvShowsManager.Models.ViewModels;

namespace TvShowsManager.Services.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowData _data;
        private readonly IMapper _mapper;

        public ShowService(
            IShowData data,
            IMapper mapper) {
            _data = data;
            _mapper = mapper;
        }
        public async Task CreateShowAsync(ShowViewModel show)
        {
            try
            {
                if (show != null)
                {
                    Show newShow = _mapper.Map<Show>(show);
                    newShow.CreateBy = "User";
                    newShow.CreateDate = DateTime.Now;

                    await _data.AddShowAsync(newShow);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ShowViewModel>> GetShowsByTypeAsync(ShowType showType)
        {
            try
            {
                List<Show> shows = await _data.GetShowsByTypeAsync(showType);
                List<ShowViewModel> showsByType = _mapper.Map<List<ShowViewModel>>(shows);
                return showsByType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ShowViewModel>> GetShowsByPlatformAsync(Platform platform)
        {
            try
            {
                List<Show> shows = await _data.GetShowByPlatformAsync(platform);
                List<ShowViewModel> showsByPlatform = _mapper.Map<List<ShowViewModel>>(shows);
                return showsByPlatform;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ShowViewModel>> GetShowsAsync()
        {
            try
            {
                List<Show> shows = await _data.GetShowsAsync();
                List<ShowViewModel> allShows = _mapper.Map<List<ShowViewModel>>(shows);
                return allShows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ShowViewModel>> GetFavoriteShowsAsync()
        {
            try
            {
                List<Show> shows = await _data.GetFavoriteShowsAsync();
                List<ShowViewModel> favoriteShows = _mapper.Map<List<ShowViewModel>>(shows);
                return favoriteShows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SetShowFavoriteStatusByIdAsync(int id)
        {
            try
            {
                Show showToSetFavorite = await _data.GetShowByIdAsync(id);
                if (showToSetFavorite != null && !showToSetFavorite.IsDeleted)
                {
                    showToSetFavorite.Favorite = !showToSetFavorite.Favorite;
                    await _data.UpdateShowAsync(showToSetFavorite);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteShowAsync(int id)
        {
            try
            {
                Show showToDelete = await _data.GetShowByIdAsync(id);
                if (showToDelete != null && !showToDelete.IsDeleted)
                {
                    showToDelete.IsDeleted = true;
                    await _data.UpdateShowAsync(showToDelete);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
