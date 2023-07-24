namespace TvShowsManager.Models.DataModels
{
    public class BaseAudit
    {
        public string CreateBy { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public string UpdateBy { get; set; } = string.Empty;

        public DateTime UpdateDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
