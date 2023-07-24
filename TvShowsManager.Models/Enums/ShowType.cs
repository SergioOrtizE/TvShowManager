using System.ComponentModel;

namespace TvShowsManager.Models.Enums
{
    public enum ShowType
    {
        [Description("Action")]
        Action,
        [Description("Comedy")]
        Comedy,
        [Description("Terror")]
        Terror,
        [Description("Thriller")]
        Thriller,
        [Description("Drama")]
        Drama,
        [Description("Fantasy")]
        Fantasy,
        [Description("Science Fiction")]
        SciFi,
        [Description("Animated")]
        Animated,
        [Description("Musical")]
        Musical,
        [Description("Detective")]
        Detective,
        [Description("Documental")]
        Documental,
        [Description("Science and Knowledge")]
        Science
    }
}
