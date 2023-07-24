using Moq;
using TvShowsManager.Services.Services;
using TvShowsManager.Data.Interfaces;
using AutoMapper;
using TvShowsManager.Models.DataModels;
using TvShowsManager.Models.ViewModels;
using TvShowsManager.Models.Enums;
using TvShowsManager.Services.Utils;

namespace TvShowsManager.Tests
{
    public class ShowServiceTests
    {
        [Fact]
        public async Task CreateShowAsync_ShouldAddShow_WhenShowIsValid()
        {
            // Arrange
            var mockShowData = new Mock<IShowData>();
            var mockMapper = new Mock<IMapper>();
            var service = new ShowService(mockShowData.Object, mockMapper.Object);

            var showViewModel = new ShowViewModel();

            var show = new Show();
            mockMapper.Setup(x => x.Map<Show>(showViewModel)).Returns(show);

            // Act
            await service.CreateShowAsync(showViewModel);

            // Assert
            mockShowData.Verify(x => x.AddShowAsync(show), Times.Once);
        }

        [Fact]
        public async Task GetShowsByTypeAsync_ShouldReturnShowsOfGivenType()
        {
            // Arrange
            ShowType showType = ShowType.Action;
            var mockShowData = new Mock<IShowData>();

            // Initialize AutoMapper with your application profile
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            var mapper = new Mapper(configuration);

            var service = new ShowService(mockShowData.Object, mapper);

            var shows = new List<Show>() { new Show(), new Show() };
            mockShowData.Setup(x => x.GetShowsByTypeAsync(showType)).ReturnsAsync(shows);

            // Act
            var result = await service.GetShowsByTypeAsync(showType);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetShowsByPlatform_ShouldReturnShowsOfGivenPlatform()
        {
            // Arrange
            Platform platform = Platform.Netflix;
            var mockShowData = new Mock<IShowData>();

            // Initialize AutoMapper with your application profile
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            var mapper = new Mapper(configuration);

            var service = new ShowService(mockShowData.Object, mapper);

            var shows = new List<Show>() { new Show(), new Show() };
            mockShowData.Setup(x => x.GetShowByPlatformAsync(platform)).ReturnsAsync(shows);

            // Act
            var result = await service.GetShowsByPlatformAsync(platform);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetShowsAsync_ShouldReturnAllShows()
        {
            // Arrange
            var shows = new List<Show>() { new Show(), new Show(), new Show() };
            var mockShowData = new Mock<IShowData>();
            var mockMapper = new Mock<IMapper>();

            // Setup the mapper to return a list of ShowViewModels when it maps a List<Show>
            mockMapper.Setup(m => m.Map<List<ShowViewModel>>(It.IsAny<List<Show>>())).Returns(new List<ShowViewModel> { new ShowViewModel(), new ShowViewModel(), new ShowViewModel() });

            var service = new ShowService(mockShowData.Object, mockMapper.Object);

            mockShowData.Setup(x => x.GetShowsAsync()).ReturnsAsync(shows);

            // Act
            var result = await service.GetShowsAsync();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetFavoriteShowsAsync_ShouldReturnFavoriteShows()
        {
            // Arrange
            var shows = new List<Show>();
            var mockShowData = new Mock<IShowData>();
            var mockMapper = new Mock<IMapper>();

            // Setup the mapper to return an empty list of ShowViewModels when it maps an empty List<Show>
            mockMapper.Setup(m => m.Map<List<ShowViewModel>>(It.IsAny<List<Show>>())).Returns(new List<ShowViewModel>());

            var service = new ShowService(mockShowData.Object, mockMapper.Object);

            mockShowData.Setup(x => x.GetFavoriteShowsAsync()).ReturnsAsync(shows);

            // Act
            var result = await service.GetFavoriteShowsAsync();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task SetShowFavoriteStatusByIdAsync_ShouldToggleFavoriteStatus()
        {
            // Arrange
            int id = 1;
            var originalShow = new Show() { Favorite = false };
            var expectedShow = new Show() { Favorite = true };  // Create a separate Show object with the expected Favorite status

            var mockShowData = new Mock<IShowData>();
            var mockMapper = new Mock<IMapper>();
            var service = new ShowService(mockShowData.Object, mockMapper.Object);

            mockShowData.Setup(x => x.GetShowByIdAsync(id)).ReturnsAsync(originalShow);

            // Act
            await service.SetShowFavoriteStatusByIdAsync(id);

            // Assert
            mockShowData.Verify(x => x.UpdateShowAsync(It.Is<Show>(s => s.Favorite == expectedShow.Favorite)), Times.Once);
        }

        [Fact]
        public async Task DeleteShowAsync_ShouldDeleteShow()
        {
            // Arrange
            int id = 1;
            var originalShow = new Show() { IsDeleted = false };
            var expectedShow = new Show() { IsDeleted = false }; // Create a separate Show object with the expected Favorite status

            var mockShowData = new Mock<IShowData>();
            var mockMapper = new Mock<IMapper>();
            var service = new ShowService(mockShowData.Object, mockMapper.Object);

            mockShowData.Setup(x => x.GetShowByIdAsync(id)).ReturnsAsync(originalShow);

            // Act
            await service.DeleteShowAsync(id);

            // Assert
            mockShowData.Verify(x => x.UpdateShowAsync(It.Is<Show>(s => s.IsDeleted == !expectedShow.IsDeleted)), Times.Once);
        }
    }
}