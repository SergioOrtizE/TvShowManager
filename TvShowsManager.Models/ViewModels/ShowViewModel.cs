namespace TvShowsManager.Models.ViewModels
{
    public class ShowViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Favorite { get; set; } = string.Empty;

        public string ShowType { get; set; } = string.Empty;

        public string Platform { get; set; } = string.Empty;
    }
}
