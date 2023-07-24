using Microsoft.EntityFrameworkCore;
using TvShowsManager.DataContext;
using TvShowsManager.Models.DataModels;
using TvShowsManager.Models.Enums;

namespace TvShowsManager.Cli
{
    public static class DbInitializer
    {
        public static void Initialize(TvShowContext context)
        {
            //We will use this process to create the database if it is the first the application runs and use a try catch to handle errors.
            try
            {
                // Ensure the database is created and apply migrations
                context.Database.Migrate();

                // Seed the database if necessary
                if (!context.Shows.Any())
                {
                    context.Shows.AddRange(
                        new Show
                        {
                            Title = "Vikings",
                            ShowType = ShowType.Action,
                            Platform = Platform.Netflix,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Stranger Things",
                            ShowType = ShowType.Terror,
                            Platform = Platform.Netflix,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "The Witcher",
                            ShowType = ShowType.SciFi,
                            Platform = Platform.Netflix,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Senfield",
                            ShowType = ShowType.Comedy,
                            Platform = Platform.Netflix,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Castlevania",
                            ShowType = ShowType.Animated,
                            Platform = Platform.Netflix,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "The Peripheral",
                            ShowType = ShowType.SciFi,
                            Platform = Platform.PrimeVideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Jack Ryan",
                            ShowType = ShowType.Action,
                            Platform = Platform.PrimeVideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Libre de Reír",
                            ShowType = ShowType.Comedy,
                            Platform = Platform.PrimeVideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Good Omens",
                            ShowType = ShowType.Comedy,
                            Platform = Platform.PrimeVideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Yu-Gi-Oh",
                            ShowType = ShowType.Animated,
                            Platform = Platform.PrimeVideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Euphoria",
                            ShowType = ShowType.Drama,
                            Platform = Platform.HboMax,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Two Broke Girls",
                            ShowType = ShowType.Comedy,
                            Platform = Platform.HboMax,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "The Sopranos",
                            ShowType = ShowType.Drama,
                            Platform = Platform.HboMax,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "True Detective",
                            ShowType = ShowType.Detective,
                            Platform = Platform.HboMax,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "The Mandalorian",
                            ShowType = ShowType.SciFi,
                            Platform = Platform.Disney,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Secret Invasion",
                            ShowType = ShowType.SciFi,
                            Platform = Platform.Disney,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "La Ciencia de los Absurdo",
                            ShowType = ShowType.Science,
                            Platform = Platform.Disney,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Cosmos",
                            ShowType = ShowType.Science,
                            Platform = Platform.Disney,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Apollo: Back to The Moon",
                            ShowType = ShowType.Documental,
                            Platform = Platform.Disney,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "The X-Files",
                            ShowType = ShowType.SciFi,
                            Platform = Platform.Clarovideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "The Nanny",
                            ShowType = ShowType.Comedy,
                            Platform = Platform.Clarovideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "One Piece",
                            ShowType = ShowType.Animated,
                            Platform = Platform.Clarovideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Hippocrate",
                            ShowType = ShowType.Drama,
                            Platform = Platform.Clarovideo,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Halo",
                            ShowType = ShowType.SciFi,
                            Platform = Platform.Paramount,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Sabrina: The Teenage Witch",
                            ShowType = ShowType.Comedy,
                            Platform = Platform.Paramount,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Yellowjackets",
                            ShowType = ShowType.Terror,
                            Platform = Platform.Paramount,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Bosé Unplugged",
                            ShowType = ShowType.Musical,
                            Platform = Platform.Paramount,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Shingeki No Kyojin",
                            ShowType = ShowType.Animated,
                            Platform = Platform.Crunchyroll,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        },
                        new Show
                        {
                            Title = "Dragon Ball Super",
                            ShowType = ShowType.Animated,
                            Platform = Platform.Crunchyroll,
                            CreateBy = "System",
                            CreateDate = DateTime.Now
                        }
                    );

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //We handle if there are any exceptions during the database creation and seeding
                Console.WriteLine("An error occurred while initializing the database: " + ex.Message);

                throw;
            }
        }
    }
}
