using EVideoPrime.API.Entities.VideoPrime;

namespace EVideoPrime.API.Abstractions.Models.VideoPrime
{
    public partial class MovieModel
    {
        public MovieModel()
        {
            Languages = new HashSet<LanguageModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Thumbnail { get; set; }
        public string Banner { get; set; }
        public string Duration { get; set; }
        public string VideoUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }

        public Category CategoryDetail { get; set; }
        public virtual ICollection<LanguageModel> Languages { get; set; }
    }
}