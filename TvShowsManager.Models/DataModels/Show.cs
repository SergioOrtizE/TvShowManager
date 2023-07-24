using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TvShowsManager.Models.Enums;

namespace TvShowsManager.Models.DataModels
{
    public class Show : BaseAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool Favorite { get; set; }

        public ShowType ShowType { get; set; }

        public Platform Platform { get; set; }
    }
}
