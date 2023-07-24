using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowsManager.Models.Enums;
using TvShowsManager.Models.Utils;
using TvShowsManager.Models.ViewModels;
using TvShowsManager.Services.Interfaces;

namespace TvShowsManager.Cli
{
    public class MenuManager
    {
        private readonly IShowService _showService;

        public MenuManager(IShowService showService)
        {
            _showService = showService;
        }

        public async Task ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please type an option:");
                Console.WriteLine("--> new - To add a new show to the list");
                Console.WriteLine("--> list - Show all TV Shows");
                Console.WriteLine("--> Enter the id number of a show to set as favorite");
                Console.WriteLine("--> favorites - Show favorite TV Shows");
                Console.WriteLine("--> platform - Filter TV Shows by platform");
                Console.WriteLine("--> genre - Filter TV Shows by type");
                Console.WriteLine("--> delete - Delete a TV Show");
                Console.WriteLine("--> exit - Exit the program");

                string option = Console.ReadLine() ?? string.Empty;

                if (option != null)
                {
                    option = option.ToLower();

                    switch (option)
                    {
                        case "new":
                            Console.WriteLine("Please enter the Title for the show:");
                            string newShowTitle = Console.ReadLine() ?? string.Empty;

                            Console.WriteLine("Please enter the platform number from the list:");
                            Console.WriteLine("1.- Hbo Max");
                            Console.WriteLine("2.- Netflix");
                            Console.WriteLine("3.- Amazon Prime Video");
                            Console.WriteLine("4.- Disney Plus");
                            Console.WriteLine("5.- Paramount Plus");
                            Console.WriteLine("6.- Vix Plus");
                            Console.WriteLine("7.- Lionsgate Plus");
                            Console.WriteLine("8.- Claro Video");
                            Console.WriteLine("9.- Crunchyroll");
                            string newShowPlatform = Console.ReadLine() ?? string.Empty;

                            Console.WriteLine("Please enter the genre number from the list:");
                            Console.WriteLine("1.- Action");
                            Console.WriteLine("2.- Comedy");
                            Console.WriteLine("3.- Terror");
                            Console.WriteLine("4.- Thriller");
                            Console.WriteLine("5.- Drama");
                            Console.WriteLine("6.- Fantasy");
                            Console.WriteLine("7.- Science Fiction");
                            Console.WriteLine("8.- Animated");
                            Console.WriteLine("9.- Musical");
                            Console.WriteLine("10.- Detective");
                            Console.WriteLine("11.- Documental");
                            Console.WriteLine("12.- Science and Knowledge");
                            string newShowGenre = Console.ReadLine() ?? string.Empty;

                            Console.WriteLine("Do you want to set this new show as Favorite? Please enter the number of your choice:");
                            Console.WriteLine("1.- Yes");
                            Console.WriteLine("2.- No");
                            string setFavorite = Console.ReadLine() ?? string.Empty;
                            string setNewShowFavorite = string.Empty;

                            if (int.TryParse(setFavorite, out int setFavoriteOption))
                            {
                                setNewShowFavorite = setFavoriteOption == 1 ? "*" : string.Empty;
                            }

                            ShowViewModel newShow = new ShowViewModel() { 
                                Title = newShowTitle ?? string.Empty,
                                Favorite = setNewShowFavorite,
                            };

                            if (int.TryParse(newShowPlatform, out int newShowPlatformInt)){
                                newShowPlatformInt--;
                                if (Enum.IsDefined(typeof(Platform), newShowPlatformInt))
                                {
                                    Platform newShowPlatformEnum = (Platform)newShowPlatformInt;
                                    newShow.Platform = newShowPlatformEnum.ToString();
                                }
                            }

                            if(int.TryParse(newShowGenre, out int newShowTypeint))
                            {
                                newShowTypeint--;
                                if (Enum.IsDefined(typeof(ShowType), newShowTypeint))
                                {
                                    ShowType newShowTypeEnum = (ShowType)newShowTypeint;
                                    newShow.ShowType = newShowTypeEnum.ToString();
                                }
                            }

                            await _showService.CreateShowAsync(newShow);

                            Console.WriteLine("New show has been added.");

                            break;
                        case "list":
                            var shows = await _showService.GetShowsAsync();
                            foreach (var show in shows)
                            {
                                Console.WriteLine($"ID: {show.Id} TITLE: {show.Title}{show.Favorite} PLATFORM: {show.Platform} GENRE: {show.ShowType}.");
                            }
                            break;
                        case "platform":
                            Console.WriteLine("Please select the number of the platform in the list:");
                            Console.WriteLine("1.- Hbo Max");
                            Console.WriteLine("2.- Netflix");
                            Console.WriteLine("3.- Amazon Prime Video");
                            Console.WriteLine("4.- Disney Plus");
                            Console.WriteLine("5.- Paramount Plus");
                            Console.WriteLine("6.- Vix Plus");
                            Console.WriteLine("7.- Lionsgate Plus");
                            Console.WriteLine("8.- Claro Video");
                            Console.WriteLine("9.- Crunchyroll");
                            
                            string platform = Console.ReadLine() ?? string.Empty;

                            if (int.TryParse(platform, out int platformOption))
                            {
                                platformOption--;
                                if (Enum.IsDefined(typeof(Platform), platformOption))
                                {
                                    Platform platformEnum = (Platform)platformOption;
                                    var showsByPlatform = await _showService.GetShowsByPlatformAsync(platformEnum);
                                    foreach (var show in showsByPlatform)
                                    {
                                        Console.WriteLine($"ID: {show.Id} TITLE: {show.Title}{show.Favorite} PLATFORM: {show.Platform} GENRE: {show.ShowType}.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number from the list.");
                            }
                            break;
                        case "genre":
                            Console.WriteLine("Please select the number of the genre in the list:");
                            Console.WriteLine("1.- Action");
                            Console.WriteLine("2.- Comedy");
                            Console.WriteLine("3.- Terror");
                            Console.WriteLine("4.- Thriller");
                            Console.WriteLine("5.- Drama");
                            Console.WriteLine("6.- Fantasy");
                            Console.WriteLine("7.- Science Fiction");
                            Console.WriteLine("8.- Animated");
                            Console.WriteLine("9.- Musical");
                            Console.WriteLine("10.- Detective");
                            Console.WriteLine("11.- Documental");
                            Console.WriteLine("12.- Science and Knowledge");

                            string genre = Console.ReadLine() ?? string.Empty;

                            if (int.TryParse(genre, out int genreOption))
                            {
                                genreOption--;
                                if (Enum.IsDefined(typeof(ShowType), genreOption))
                                {
                                    ShowType genreEnum = (ShowType)genreOption;
                                    var showsByGenre = await _showService.GetShowsByTypeAsync(genreEnum);
                                    foreach (var show in showsByGenre)
                                    {
                                        Console.WriteLine($"ID: {show.Id} TITLE: {show.Title}{show.Favorite} PLATFORM: {show.Platform} GENRE: {show.ShowType}.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number from the list.");
                            }
                            break;
                        case "favorites":
                            var favoriteShows = await _showService.GetFavoriteShowsAsync();
                            foreach (var show in favoriteShows)
                            {
                                Console.WriteLine($"ID: {show.Id} TITLE: {show.Title}{show.Favorite} PLATFORM: {show.Platform} GENRE: {show.ShowType}.");
                            }
                            break;
                        case "delete":
                            var showsList = await _showService.GetShowsAsync();
                            foreach (var show in showsList)
                            {
                                Console.WriteLine($"ID: {show.Id} TITLE: {show.Title}{show.Favorite} PLATFORM: {show.Platform} GENRE: {show.ShowType}.");
                            }
                            Console.WriteLine("Please enter the Id of the show you want to Delete:");
                            string showToDelete = Console.ReadLine() ?? string.Empty;

                            if (int.TryParse(showToDelete, out int showIdToDelete))
                            {
                                await _showService.DeleteShowAsync(showIdToDelete);
                                Console.WriteLine("Show was deleted from the list.");
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid ID number.");
                            }
                            break;
                        case "exit":
                            exit = true;
                            break;
                        default:
                            if (int.TryParse(option, out int showId))
                            {
                                await _showService.SetShowFavoriteStatusByIdAsync(showId);
                                Console.WriteLine("Show was set as Favorite.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid option. Please try again.");
                            }
                            break;
                    }
                }
            }
        }
    }
}
